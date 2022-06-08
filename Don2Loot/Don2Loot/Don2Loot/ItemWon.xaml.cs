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
    public partial class ItemWon : ContentPage
    {
        public ItemWon()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        private void backButton(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
        async void collectionPageButton(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new CollectionPage(), this);
            await Navigation.PopAsync();
        }

        async void ItemWonButton(object sender, EventArgs e)
        {
            ItemDisplayAsync();
            openCrateButton.IsVisible = false;
        }

        private async void ItemDisplayAsync()
        {
            //Temporary hard-coding a variable. Future: get chest name from the store page
            String chestName = "anime";
            Reward recievedReward = await App.Database.getCrateDrop(chestName);
            rewardImageBind.Source = recievedReward.RewardImage;
        }
    }
}