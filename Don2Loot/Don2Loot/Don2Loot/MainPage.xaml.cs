using Plugin.LocalNotification;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;


namespace Don2Loot
{
    public partial class MainPage : ContentPage
    {

        public ObservableCollection<DescriptionInfo> description = new ObservableCollection<DescriptionInfo>();
        ObservableCollection<Task> tasks = null;

        public MainPage()
        {
            InitializeComponent();
            notificationTest();
            this.BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            tasks = new ObservableCollection<Task>(await App.Database.getTask());
            mainPageListView.ItemsSource = description;
            List<User> users = new List<User>();
            users = await App.Database.getUser();
        }

        public class DescriptionInfo
        {
            public string Name { get; set; }
        }
  

        //private void OnLocalNotificationTapped(NotificationEventArgs e)
        //{
        //    var notification = new NotificationRequest
        //    {
        //        BadgeNumber = 1,
        //        Description = "Did you take any steps into make your future better?",
        //        Title = "What did you do Today?",
        //        ReturningData = "Dummy Data",
        //        NotificationId = 1337,
        //        Schedule =
        //        {
        //           NotifyTime = DateTime.Now.AddSeconds(10)
        //        }

        //    };
        //    NotificationCenter.Current.Show(notification);
        //}

        //protected override async void OnAppearing()
        //{
        //    List<User> users = new List<User>();
        //    users = await App.Database.getUser();
        //    int coins = users[0].UserCoins;
        //    mainPageCoins.Text = coins.ToString();
        //}

        private void notificationTest()
        {
            var notification = new NotificationRequest
            {
                BadgeNumber = 1,
                Description = "Did you take any steps into make your future better?",
                Title = "What did you do Today?",
                ReturningData = "Dummy Data",
                NotificationId = 1337,
                Schedule =
                {
                   NotifyTime = DateTime.Now.AddSeconds(10)
                }

            };
            NotificationCenter.Current.Show(notification);

        }
        async void collectionPageButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CollectionPage());
        } 

        async void newTaskButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewTask());
        }

        async void TaskPageButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TaskPage());
        }

        async void TestPageButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TaskCompleted());
        }
        async void ItemWonButton(object sender, EventArgs e) 
        {
            Chest chest = null;
            await Navigation.PushAsync(new ItemWon(chest));
        }

        async void storePageButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StorePage());
        }


    }
}
