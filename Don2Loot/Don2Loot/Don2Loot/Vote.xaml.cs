using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Don2Loot
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Vote : ContentPage
    {
        public Vote()
        {
            InitializeComponent();
        }

        //Update coins
        protected override async void OnAppearing() {
            base.OnAppearing();
            List<User> users = new List<User>();
            users = await App.Database.getUser();
            voteCoins.Text = users[0].UserCoins.ToString();
        }
        async void backButton(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        async void setBackButton(object sender, EventArgs e)
        {
            //do something aka set notification, cancel streak, etc.
            await DisplayAlert("SADGE", "YOU LOST YOUR STREAK", "Ok");  //testing purposes
        }
        async void victoryButton(object sender, EventArgs e)
        {
            //do something else aka set notification, advance streak, award points, etc.
            await DisplayAlert("HAP", "GOOD JOB", "Ok");    //testing purposes
        }
    }
}