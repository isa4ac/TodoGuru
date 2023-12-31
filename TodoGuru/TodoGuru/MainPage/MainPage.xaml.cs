﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TodoGuru
{

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            TodoCollectionView.ItemsSource = (await App.Database.getTaskAsync()).OrderBy(task => task.complete).ThenBy(task => task.dueDate);
        }

        private async void OnCreateTaskClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTaskPage.AddTaskPage());
        }

        private async void SelectedTaskRow(object sender, SelectionChangedEventArgs e)
        {
            var task = e.CurrentSelection.FirstOrDefault() as UserTask;
            await Navigation.PushAsync(new TaskView.TaskView(task));
        }

        private async void OnCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                var selectedTask = checkBox.BindingContext as UserTask;
                if (selectedTask != null)
                {
                    selectedTask.complete = checkBox.IsChecked;
                    await App.Database.updateUserTaskAsync(selectedTask);
                }
            }
        }

        private async void OnViewByCategoryClicked(object sender, EventArgs e)
        { 

            await Navigation.PushAsync(new CategoryPage());
        }
    }
}