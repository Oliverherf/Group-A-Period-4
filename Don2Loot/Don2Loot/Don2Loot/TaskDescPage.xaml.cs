using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Don2Loot {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskDescPage : ContentPage {
        public TaskDescPage() {
            InitializeComponent();
        }

        //Make sure coins are updated when page is opened
        protected override async void OnAppearing() {
            base.OnAppearing();
            List<User> users = new List<User>();
            users = await App.Database.getUser();
            taskCoins.Text = users[0].UserCoins.ToString();
        }
    }
}