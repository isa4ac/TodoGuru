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
            _allCategoryTasks = categoryTasks;
        }

        public List<string> getCatagoryNames()
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

            categoryPicker.ItemsSource = getCatagoryNames();
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
                var selectedCategoryTasks = _allCategoryTasks.Find(c => c.CategoryName == selectedCategory);
                CategoryCollectionView.ItemsSource = selectedCategoryTasks.Tasks;
            }
        }
    }
}