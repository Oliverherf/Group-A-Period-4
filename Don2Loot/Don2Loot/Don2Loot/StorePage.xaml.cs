﻿using DLToolkit.Forms.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Don2Loot
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StorePage : ContentPage
    {
        public ICommand openCrateCommand => new Command(openCrate);
        public StorePage()
        {
            InitializeComponent();
            FlowListView.Init();
            this.BindingContext = this;
            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            List<Chest> chests = await App.Database.getChest();
            storePageView.FlowItemsSource = chests;
        }

            private void backButton(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void openCrate(object sender)
        {
            //some function that remembers the crate and brings to crate opening page ((Chest)sender)
            //Navigation.PushAsync(new )-----------------------------------------------------------------Discuss this with team----------
        }
    }
}