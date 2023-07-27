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
                    complete = false
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

