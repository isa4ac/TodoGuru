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
            TodoCollectionView.ItemsSource = await App.Database.getTaskAsync();
        }
        private async void OnCreateTaskClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTaskPage.AddTaskPage());
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