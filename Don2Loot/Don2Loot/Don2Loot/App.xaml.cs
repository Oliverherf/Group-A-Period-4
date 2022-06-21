using Plugin.LocalNotification;
using Plugin.LocalNotification.EventArgs;
using Plugin.LocalNotification.Json;
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
        private readonly NotificationSerializer notificationSerializer;
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
            notificationSerializer = new NotificationSerializer();
            NotificationCenter.Current.NotificationTapped += OnLocalNotificationTapped;
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
        private async void OnLocalNotificationTapped(NotificationEventArgs e)
        {
            var returningData = e.Request.ReturningData;
            Task currentTask;
            if (int.TryParse(returningData, out var id))
            {
                List<Task> tasks = new List<Task>();
                tasks = await App.Database.getTask();
                currentTask = tasks[id];
                await ((ContentPage)MainPage).Navigation.PushModalAsync(new Vote(currentTask));
            }
            else
            {
                await ((NavigationPage)MainPage).DisplayAlert("Error", "Task could not be found", "Ok");
            }

            

        }
    }
}
