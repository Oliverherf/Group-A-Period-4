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
        Task currentTask;
        public Vote(Task currentTask)
        {
            InitializeComponent();
            this.currentTask = currentTask;
        }

        //Update coins
        protected override async void OnAppearing() {
            base.OnAppearing();
            List<User> users = new List<User>();
            users = await App.Database.getUser();
            voteCoins.Text = users[0].UserCoins.ToString();

            taskQuestion.Text = "How did you do on " + currentTask.TaskName;
            
        }
        async void backButton(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        async void setBackButton(object sender, EventArgs e)
        {
            //do something aka set notification, cancel streak, etc.
            await DisplayAlert("U+1F62D", "YOU LOST YOUR STREAK", "Ok");  //testing purposes
            List<User> users = new List<User>();
            users = await App.Database.getUser();
            App.Database.updateUserStreak(users[0].UserEmail, 0);
            await Navigation.PopAsync();
        }
        async void victoryButton(object sender, EventArgs e)
        {
            //do something else aka set notification, advance streak, award points, etc.
            await DisplayAlert("U+1F604", "GOOD JOB", "Ok");    //testing purposes
            List<User> users = new List<User>();
            users = await App.Database.getUser();
            int newStreak = users[0].UserStreak + 1;
            int amountOfCoins = users[0].UserCoins + 100 + (10 * users[0].UserStreak); //some calculation has to be done, idk what the calculation should be.
            App.Database.updateUserCoins(users[0].UserEmail, amountOfCoins);
            App.Database.updateUserStreak(users[0].UserEmail, newStreak);
            await Navigation.PopAsync();
        }
    }
}