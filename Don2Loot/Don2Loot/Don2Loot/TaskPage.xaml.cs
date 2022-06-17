using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using Plugin.LocalNotification;
using System.Windows.Input;
using System.Collections.Generic;

namespace Don2Loot
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskPage : ContentPage
    {
        public ICommand deleteTaskCommand => new Command(deleteButton);
        public ICommand seeTaskDetailsCommand => new Command(seeTaskDetailsButton);
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

            List<User> users = new List<User>();
            users = await App.Database.getUser();
            coinsTaskPage.Text = users[0].UserCoins.ToString();
        }

        private void Sherlock_TextChanged(object sender, TextChangedEventArgs e)
        {
            myListView.ItemsSource = tasks.Where(s => s.TaskName.Contains(e.NewTextValue));
        }
        public class TaskInfo
        {
            public string Name { get; set; }
        }

        async void myListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //await Navigation.PushAsync(new Vote((Task)sender)); Does not work yet.
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
            var task = (Task)sender;
            await App.Database.deleteTask((Task)sender);
            NotificationCenter.Current.Cancel(task.Id);
            Navigation.InsertPageBefore(new TaskPage(), this);
            await Navigation.PopAsync();
        }

        async void seeTaskDetailsButton(object sender) {
            await Navigation.PushAsync(new TaskDescPage((Task)sender));

        }
    }
}