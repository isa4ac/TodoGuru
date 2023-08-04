using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TodoGuru.TaskView
{	
	public partial class TaskView : ContentPage
	{
        UserTask userTask;

        public TaskView (UserTask userTask)
		{
			InitializeComponent ();

            this.userTask = userTask;
            nameLabel.Text = userTask.taskName;
            createDateLabel.Text = userTask.logDate;
            dueDateLabel.Text = userTask.dueDate;
            descriptionLabel.Text = userTask.description;
            completeLabel.Text = userTask.complete.ToString();
            catagoryLabel.Text = userTask.Category;
		}

        private async void UpdateTask_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditTaskPage.EditTaskPage(userTask));
        }

        private async void DeleteTask_Clicked(object sender, EventArgs e)
        {
            await App.Database.deleteUserTaskAsync(userTask);

            await Navigation.PopToRootAsync();
        }

    }
}

