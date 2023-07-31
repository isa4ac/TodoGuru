using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TodoGuru.AddTaskPage
{	
	public partial class AddTaskPage : ContentPage
	{
        public static string ShortDateFormat = "yyyy-MM-dd HH':'mm";
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
            
            List<string> categories = new List<string> { "Personal", "Work", "Home", "Others" };
            categoryPicker.ItemsSource = categories;

            // Adds an option for "Enter New Category" at the end
            categoryPicker.Items.Add("Enter New Category");

        }
        private async void OnCreateTaskClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(taskNameEntry.Text))
            {
                int newTaskId = await App.Database.saveUserTaskAsync(new UserTask
                {
                    taskName = taskNameEntry.Text,
                    logDate = DateTime.Now.ToString(ShortDateFormat),
                    dueDate = dueDatePicker.Date.ToString(ShortDateFormat), 
                    description = taskDescriptionEditor.Text,
                    complete = false,
                    Category = categoryPicker.SelectedItem as string
                });

                taskNameEntry.Text = string.Empty;

                // Display a confirmation message
                await DisplayAlert("Task Added", "New task has been added successfully", "OK");

                // Navigate back to the TaskListPage
                await Navigation.PushAsync(new MainPage());
            }
        }
    }
}

