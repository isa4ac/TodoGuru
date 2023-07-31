using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TodoGuru.TaskView
{	
	public partial class TaskView : ContentPage
	{
        public TaskView (UserTask userTask)
		{
			InitializeComponent ();

			nameLabel.Text = userTask.taskName;
            createDateLabel.Text = userTask.logDate;
            dueDateLabel.Text = userTask.dueDate;
            descriptionLabel.Text = userTask.description;
            completeLabel.Text = userTask.complete.ToString();
            catagoryLabel.Text = userTask.Category;
		}
	}
}

