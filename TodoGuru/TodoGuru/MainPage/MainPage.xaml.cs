using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TodoGuru
{

    public class TodoItem
    {
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
    }

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            TodoCollectionView.ItemsSource = (await App.Database.getTaskAsync()).OrderBy(task => task.complete);
        }

        private async void OnCreateTaskClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTaskPage.AddTaskPage());
        }

        private async void SelectedTaskRow(object sender, SelectionChangedEventArgs e)
        {
            var task = e.CurrentSelection.FirstOrDefault() as UserTask;
            await Navigation.PushAsync(new TaskView.TaskView(task));
        }

        private async void OnCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                var selectedTask = checkBox.BindingContext as UserTask;
                if (selectedTask != null)
                {
                    selectedTask.complete = e.Value;
                    await App.Database.updateUserTaskAsync(selectedTask);
                    //TaskNameLabel.TextDecoration
                    TodoCollectionView.ItemsSource = (await App.Database.getTaskAsync()).OrderBy(task => task.complete);
                }
            }
        }

        private async void OnViewByCategoryClicked(object sender, EventArgs e)
        {
            var allTasks = await App.Database.getTaskAsync();
            var categories = allTasks.Select(task => task.Category).Distinct().ToList();

            var categoryTasks = new List<CategoryTask>();
            foreach (var category in categories)
            {
                var tasksByCategory = allTasks.Where(task => task.Category == category).ToList();
                categoryTasks.Add(new CategoryTask { CategoryName = category, Tasks = tasksByCategory });
            }

            await Navigation.PushAsync(new CategoryPage(categoryTasks));
        }
    }
}