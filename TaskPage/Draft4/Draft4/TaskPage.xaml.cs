using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using Plugin.LocalNotification;

namespace Draft4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        
        public ObservableCollection<TaskInfo> task = new ObservableCollection<TaskInfo>();
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            task.Add(new TaskInfo { Name = "Working"});
            task.Add(new TaskInfo { Name = "Task2" });
            task.Add(new TaskInfo { Name = "Task3" });
            task.Add(new TaskInfo { Name = "Task4" });
            myListView.ItemsSource = task;
           // Sherlock.TextChanged += Sherlock_TextChanged;
                 
        }

        private void Sherlock_TextChanged(object sender, TextChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("test");
            myListView.ItemsSource = task.Where(s => s.Name.StartsWith(e.NewTextValue));
        }

        public class TaskInfo
        {
            public string Name { get; set; }
        }

        private void myListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var notification = new NotificationRequest
            {
                BadgeNumber = 1,
                Description = "From Zack to the loved one ",
                Title = "I love you mom",
                ReturningData = "Dummy data",
                NotificationId = 1337,
                //Android = new Plugin.LocalNotification.AndroidOption.AndroidOptions
                //{

                //}
            };

            NotificationCenter.Current.Show(notification);

            //var task = e.SelectedItem as TaskInfo;
            //DisplayAlert("Selected", $"{task.Name}\n", "OK");
        }

        private void myListView_ItemTapped(object sender, ItemTappedEventArgs e )
        {
            var task = e.Item as TaskInfo;
            DisplayAlert("Tapped", $"{task.Name}\n", "OK");
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        //private void myListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{

        //}

        //private void myListView_ItemTapped(object sender, ItemTappedEventArgs e)
        //{

        //}

        private void myListView_Refreshing(object sender, EventArgs e)
        {
            myListView.ItemsSource = null;
            myListView.ItemsSource = task;
            myListView.EndRefresh();
        }

        private async void backButton_Clicked(object sender, EventArgs e)
        {

            var notifiation = new NotificationRequest
            {
                BadgeNumber = 1,
                Description = "Test Description",
                Title = "Notification!",
                ReturningData = "Dummy Data",
                NotificationId = 1337,
                Schedule =
                {
                    NotifyTime = DateTime.Now.AddSeconds(5)
                }
            };
            await NotificationCenter.Current.Show(notifiation);
        }
    }
}
