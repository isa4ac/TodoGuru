using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TodoGuru.AddTaskPage
{	
	public partial class AddTaskPage : ContentPage
	{
        public bool newCategory = false;
        public static string logDateFormat = "MM/d/yy h':'mm tt";
        public static string dueDateFormat = "MM/d/yy";

        public AddTaskPage ()
		{
            InitializeComponent();
            newCategoryEntry.IsVisible = false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            PopulateCategoryPicker();
        }

        private void PopulateCategoryPicker()
        {
            
            List<string> categories = new List<string> { "Personal", "Work", "Home", "New Catagory", "No Category" };
            categoryPicker.ItemsSource = categories;
            categoryPicker.SelectedItem = "No Category";

            // Adds an option for "Enter New Category" at the end
            //categoryPicker.Items.Add("Enter New Category");

        }

        private async void OnCreateTaskClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(taskNameEntry.Text))
            {
                int newTaskId = await App.Database.saveUserTaskAsync(new UserTask
                {
                    taskName = taskNameEntry.Text,
                    logDate = DateTime.Now.ToString(logDateFormat),
                    dueDate = dueDatePicker.Date.ToString(dueDateFormat),
                    description = taskDescriptionEditor.Text,
                    complete = false,
                    Category = newCategoryEntry.Text == "" ? categoryPicker.SelectedItem.ToString() : newCategoryEntry.Text
                });

                taskNameEntry.Text = string.Empty;

                // Display a confirmation message
                await DisplayAlert("Task Added", "New task has been added successfully", "OK");

                // Navigate back to the TaskListPage
                await Navigation.PushAsync(new MainPage());
            }
        }

        void categoryPicker_PropertyChanged(System.Object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (categoryPicker.SelectedItem != null)
            {
                if (categoryPicker.SelectedItem.ToString() == "New Catagory")
                {
                    newCategoryEntry.IsVisible = true;
                }
            }
        }
    }
}

