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
        }

        private void collectionPageButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CollectionPage());
        }

        private void newTaskButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewTask());
        }

        private void TaskPageButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TaskPage());
        }
    }
}
