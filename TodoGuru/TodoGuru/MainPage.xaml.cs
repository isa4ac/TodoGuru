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

        private List<TodoItem> _todoItems = new List<TodoItem>();

        public MainPage()
        {
            InitializeComponent();
            TodoListView.ItemsSource = _todoItems;
        }
        private void OnAddTodoClicked(object sender, EventArgs e)
        {
            var todoItem = new TodoItem { Name = TodoEntry.Text };
            _todoItems.Add(todoItem);

            TodoEntry.Text = string.Empty;

            TodoListView.ItemsSource = null;
            TodoListView.ItemsSource = _todoItems;

        }
    }
}