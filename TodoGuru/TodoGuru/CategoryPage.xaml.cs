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
        public CategoryPage(List<CategoryTask> categoryTasks)
        {
            InitializeComponent();
            CategoryCollectionView.ItemsSource = categoryTasks;
        }

        private void PopulateCategoryPicker()
        {
            // Get all categories from the list of CategoryTasks
            List<string> categories = new List<string>();
            foreach (var categoryTask in _allCategoryTasks)
            {
                categories.Add(categoryTask.CategoryName);
            }

            categoryPicker.ItemsSource = categories;
        }

        private void OnCategorySelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTaskListForSelectedCategory();
        }

        private void UpdateTaskListForSelectedCategory()
        {
            string selectedCategory = categoryPicker.SelectedItem as string;

            if (string.IsNullOrEmpty(selectedCategory))
            {
                CategoryCollectionView.ItemsSource = _allCategoryTasks;
            }
            else
            {
                var selectedCategoryTask = _allCategoryTasks.Find(c => c.CategoryName == selectedCategory);
                CategoryCollectionView.ItemsSource = new List<CategoryTask> { selectedCategoryTask };
            }
        }
    
}
}