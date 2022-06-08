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
    }
}
