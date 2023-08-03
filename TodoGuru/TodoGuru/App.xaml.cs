using System;
using Xamarin.Forms;
using System.IO;
using Xamarin.Forms.Xaml;

namespace TodoGuru
{
    public partial class App : Application
    {
        private static Database database;
        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "userTasks.db3"));
                }

                return database;
            }
        }

        public App ()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.FromHex("#8BC800"),
                BarTextColor = Color.FromHex("#FFFFFF")
            };
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

