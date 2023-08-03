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
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            PopulateCategoryPicker();
        }

        private void PopulateCategoryPicker()
        {

            List<string> categories = new List<string> { "Personal", "Work", "Home", "No Category" };
            categoryPicker.ItemsSource = categories;
            categoryPicker.SelectedItem = "No Category";
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
                    Category = categoryPicker.SelectedItem.ToString()
                });

                taskNameEntry.Text = string.Empty;

                // Display a confirmation message
                await DisplayAlert("Task Added", "New task has been added successfully", "OK");

                // Navigate back to the TaskListPage
                await Navigation.PopAsync();
            }
        }
    }
}

