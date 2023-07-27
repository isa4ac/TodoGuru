using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TodoGuru
{

    public class TodoItem
    {
        public string Name { get; set; }
    }

    public partial class MainPage : ContentPage
    {

        public static string ShortDateFormat = "yyyy-MM-dd HH':'mm";

        public MainPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            TodoCollectionView.ItemsSource = await App.Database.getTaskAsync();
        }
        private async void OnAddTodoClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TodoEntry.Text))
            {
                int newTaskId = await App.Database.saveUserTaskAsync(new UserTask
                {
                    taskName = TodoEntry.Text,
                    logDate = DateTime.Now.ToString(ShortDateFormat),
                    dueDate = DateTime.Now.ToString(ShortDateFormat), // TO-DO: update with field data
                    description = string.Empty // TO-DO: update with user entry field
                });

                TodoEntry.Text = string.Empty;
                TodoCollectionView.ItemsSource = await App.Database.getTaskAsync();
            }
        }
    }
}