using DLToolkit.Forms.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Draft4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            FlowListView.Init(); 
            this.BindingContext = this;

            List<TaskInfo> tasks = new List<TaskInfo>
            {
                new TaskInfo{Name= "Task1" },
                new TaskInfo{Name= "Task2" },
                new TaskInfo{Name= "Task3" },
                new TaskInfo{Name= "Task4" }

            };

            myListView.FlowItemsSource = tasks;
        }

        public class TaskInfo
        {
            private string name;
            public string Name { get; set; }
        }

        //private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    myListView.ItemsSource = tasks.Where(s => s.Name.StartsWith(e.NewTextValue));
        //}

        //private void myListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{

        //}

        //private void myListView_ItemTapped(object sender, ItemTappedEventArgs e)
        //{

        //}

        //private void myListView_Refreshing(object sender, EventArgs e)
        //{
        //    myListView.ItemsSource = null;
        //    myListView.ItemsSource = task;
        //    myListView.EndRefresh();
        //}
    }
}
