using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using Plugin.LocalNotification;
using System.Windows.Input;

namespace Don2Loot
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskPage : ContentPage
    {
        public ICommand deleteTaskCommand => new Command(deleteButton);
        public ObservableCollection<TaskInfo> task = new ObservableCollection<TaskInfo>();
        ObservableCollection<Task> tasks = null;
        public TaskPage()
        {   
            InitializeComponent();
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            tasks = new ObservableCollection<Task>(await App.Database.getTask());
            myListView.ItemsSource = tasks;
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
            //var notification = new NotificationRequest
            //{
            //    BadgeNumber = 1,
            //    Description = "I believe in you",
            //    Title = "You got this king",
            //    ReturningData = "Dummy data",
            //    NotificationId = 1337,
            //};

            //NotificationCenter.Current.Show(notification);
        }

        //private void myListView_ItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //    var task = e.Item as TaskInfo;
        //    DisplayAlert("Tapped", $"{task.Name}\n", "OK");
        //}
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void backButton(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        async void deleteButton(object sender)
        {
            await App.Database.deleteTask((Task)sender);
            Navigation.InsertPageBefore(new TaskPage(), this);
            await Navigation.PopAsync();
        }
    }
}