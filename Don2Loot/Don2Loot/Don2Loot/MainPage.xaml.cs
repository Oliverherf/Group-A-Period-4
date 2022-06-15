using Plugin.LocalNotification;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Don2Loot
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            notificationTest();
        }
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
        async void VoteButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Vote());
        }
        async void ItemWonButton(object sender, EventArgs e) 
        {
            await Navigation.PushAsync(new ItemWon());
        }

        async void storePageButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StorePage());
        }
    }
}
