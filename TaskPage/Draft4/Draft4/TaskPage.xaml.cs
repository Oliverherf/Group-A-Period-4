using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

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
            var task = e.SelectedItem as TaskInfo;
            DisplayAlert("Selected", $"{task.Name}\n", "OK");
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

        private void backButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}
