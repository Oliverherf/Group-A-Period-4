using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Don2Loot
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
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Don2Loot.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            base.OnStart();
            //creates database if not already exists on launch
            if (database == null)
            {
                database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Don2Loot.db3"));
            }
        }
        protected override void OnSleep()
        {

        }
        protected override void OnResume()
        {
        }
    }
}
