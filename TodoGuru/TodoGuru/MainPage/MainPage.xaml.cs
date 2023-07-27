using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public MainPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            TodoCollectionView.ItemsSource = await App.Database.getTaskAsync();
        }
        private async void OnCreateTaskClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTaskPage.AddTaskPage());
        }
    }
}