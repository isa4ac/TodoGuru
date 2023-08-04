using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TodoGuru.EditTaskPage
{	
	public partial class EditTaskPage : ContentPage
	{
        UserTask userTask;
        public bool newCategory = false;
        public static string logDateFormat = "MM/d/yy h':'mm tt";
        public static string dueDateFormat = "MM/d/yy";

        public EditTaskPage(UserTask passedTask)
        {
            InitializeComponent();
            userTask = passedTask;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            PopulateControlsPicker();
        }

        private void PopulateControlsPicker()
        { 
            List<string> categories = new List<string> { "Personal", "Work", "Home", "No Category" };
            categoryPicker.ItemsSource = categories;
            categoryPicker.SelectedItem = userTask.Category;

            dueDatePicker.Date = DateTime.Parse(userTask.dueDate);

            taskNameEntry.Text = userTask.taskName;
            taskDescriptionEditor.Text = userTask.description;
        }

        private async void OnUpdateTaskClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(taskNameEntry.Text))
            {
                userTask.taskName = taskNameEntry.Text;
                userTask.dueDate = dueDatePicker.Date.ToString(dueDateFormat);
                userTask.description = taskDescriptionEditor.Text;
                userTask.Category = categoryPicker.SelectedItem.ToString();

                int updatedTask = await App.Database.updateUserTaskAsync(userTask);

                // Display a confirmation message
                await DisplayAlert("Task Updated", "Task has been updated successfully", "OK");

                // Navigate back to the TaskListPage
                await Navigation.PopToRootAsync();
            }
        }
    }
}

