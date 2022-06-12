using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using Plugin.LocalNotification;

namespace Don2Loot
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskPage : ContentPage
    {

        public ObservableCollection<TaskInfo> task = new ObservableCollection<TaskInfo>();
        ObservableCollection<Task> tasks = null;
        public TaskPage()
        {
            
            InitializeComponent();
            BindingContext = this;
            myListView.ItemsSource = tasks;
            // Sherlock.TextChanged += Sherlock_TextChanged;

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            tasks = new ObservableCollection<Task>(await App.Database.getTask());
            
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

        private void myListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var task = e.Item as TaskInfo;
            DisplayAlert("Tapped", $"{task.Name}\n", "OK");
        }
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void myListView_Refreshing(object sender, EventArgs e)
        {
            myListView.ItemsSource = null;
            myListView.ItemsSource = task;
            myListView.EndRefresh();
        }
        private void backButton(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}