using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        async void ItemWonButton(object sender, EventArgs e) {
            Reward receivedReward = await ItemDisplayAsync();
            openCrateButton.IsVisible = false;

            //Make loop go for 3 seconds to run the animation
            Stopwatch timerAnim = new Stopwatch();
            timerAnim.Start();
            while (timerAnim.Elapsed < TimeSpan.FromSeconds(3)) {
                //Make orange background disapperar
                await openCrateBackground.FadeTo(0, 100, Easing.SinInOut);
                openCrateBackground.IsVisible = false;
                //Make the frame go white
                animationOpeningBackground.Opacity = 0;
                animationOpeningBackground.IsVisible = true;
                await animationOpeningBackground.FadeTo(100, 150, Easing.SinIn);
                //Make white frame fade away
                await animationOpeningBackground.FadeTo(0, 100, Easing.SinInOut);
                animationOpeningBackground.IsVisible = false;
                //Make orange frame appear again
                openCrateBackground.Opacity = 0;
                openCrateBackground.IsVisible = true;
                await openCrateBackground.FadeTo(100, 250, Easing.SinIn);
            }
            timerAnim.Stop();
            //Make orange background disapperar
            await openCrateBackground.FadeTo(0, 100, Easing.SinInOut);
            openCrateBackground.IsVisible = false;
            //Make the frame go white
            animationOpeningBackground.Opacity = 0;
            animationOpeningBackground.IsVisible = true;
            await animationOpeningBackground.FadeTo(100, 150, Easing.SinIn);
            //Make white frame fade away
            await animationOpeningBackground.FadeTo(0, 100, Easing.SinInOut);
            animationOpeningBackground.IsVisible = false;
            //Make orange frame appear again
            afterOpeningBackground.Opacity = 0;
            afterOpeningBackground.IsVisible = true;
            await afterOpeningBackground.FadeTo(100, 250, Easing.SinIn);
            openCrateBackground.IsVisible = false;

            timerAnim.Reset();
            rewardImageBind.IsVisible = true;

            //Display item rarity
            rarityTypeLabel.IsVisible = true;
            switch (receivedReward.RewardRarity) {
                case 1:
                    rarityTypeLabel.Text = "Legendary item";
                    break;
                case 2:
                    rarityTypeLabel.Text = "Rare item";
                    break;
                case 3:
                    rarityTypeLabel.Text = "Popular item";
                    break;
                case 4:
                    rarityTypeLabel.Text = "Common item";
                    break;
            }
        }

        private async Task<Reward> ItemDisplayAsync()
        {
            //Temporary hard-coding a variable. Future: get chest name from the store page
            String chestName = "anime";
            Reward recievedReward = await App.Database.getCrateDrop(chestName);
            rewardImageBind.Source = recievedReward.RewardImage;
            return recievedReward;
            
        }

    }
}