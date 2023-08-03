using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoGuru
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryPage : ContentPage
    {
        private List<CategoryTask> _allCategoryTasks;
        public CategoryPage()
        {
            InitializeComponent();
            CategoryCollectionView.ItemsSource = null;
        }

        public List<string> getCategoryNames()
        {
            List<string> categories = new List<string>();
            foreach (var category in _allCategoryTasks)
            {
                if (category.CategoryName != null)
                {
                    categories.Add(category.CategoryName);
                }
            }

            return categories;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var allTasks = await App.Database.getTaskAsync();
            var categories = allTasks.Select(task => task.Category).Distinct().ToList();

            var categoryTasks = new List<CategoryTask>();
            foreach (var category in categories)
            {
                var tasksByCategory = allTasks.Where(task => task.Category == category).ToList();
                categoryTasks.Add(new CategoryTask { CategoryName = category, Tasks = tasksByCategory });
            }

            _allCategoryTasks = categoryTasks;
            categoryPicker.ItemsSource = getCategoryNames();
            UpdateTaskListForSelectedCategory();
        }

        private void OnCategorySelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTaskListForSelectedCategory();
        }

        private void UpdateTaskListForSelectedCategory()
        {
            string selectedCategory = categoryPicker.SelectedItem as string;
            if (selectedCategory != null)
            {
                var selectedCategoryTasks = _allCategoryTasks.Find(c => c.CategoryName == selectedCategory);
                CategoryCollectionView.ItemsSource = selectedCategoryTasks.Tasks.OrderBy(task => task.complete).ThenBy(task => task.dueDate);
            }
        }

        private async void SelectedTaskRow(object sender, SelectionChangedEventArgs e)
        {
            var task = e.CurrentSelection.FirstOrDefault() as UserTask;
            await Navigation.PushAsync(new TaskView.TaskView(task));
            UpdateTaskListForSelectedCategory();
        }

        private async void OnCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                var selectedTask = checkBox.BindingContext as UserTask;
                if (selectedTask != null)
                {
                    selectedTask.complete = checkBox.IsChecked;
                    await App.Database.updateUserTaskAsync(selectedTask);
                }
            }
        }
    }
}