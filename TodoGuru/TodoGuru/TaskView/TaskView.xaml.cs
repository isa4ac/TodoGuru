﻿using System;
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
        private async void DeleteTask_Clicked(object sender, EventArgs e)
        {
            await App.Database.deleteUserTaskAsync(userTask);

            // Navigate back to the previous page or any other page as you see fit
            await Navigation.PopAsync();
        }

    }
}

