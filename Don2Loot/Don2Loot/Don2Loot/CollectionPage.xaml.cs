﻿using DLToolkit.Forms.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Don2Loot
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CollectionPage : ContentPage
    {
        
        
        public CollectionPage()
        {
            InitializeComponent();
            FlowListView.Init();
            this.BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //grabbing rewards from database and placing it in local variable
            List<Reward> rewards = new List<Reward>();
            rewards = await App.Database.getReward();

            //creating groups to organize rewards based on what chest they were in
            var groupByLastNamesQuery =
            from reward in rewards
            group reward by reward.ChestName into newGroup
            orderby newGroup.Key
            select newGroup;

            var images2 = groupByLastNamesQuery.ToList();

            List<imageGroup> images = new List<imageGroup>();
            //checks if database isnt empty
            if(images2.Count != 0)
            {
                //loop the list in images2
                for (int i = 0; i <= images2.Count; i++)
                {
                    //loop list in images
                    for (int j = 0; j <= images.Count; j++)
                    {
                        //check whether there are image lists
                        if (images.Count == 0)
                        {
                            //make list
                            images.Add(new imageGroup(images2[i].Key));

                            //loop add the images to the list
                            foreach (var image in images2[i])
                            {
                                //checks whether image is unlocked and able to be viewed
                                if (!image.isUnlocked)
                                {
                                    images[j].Add(new image() { Image = image.RewardImage });
                                }
                            }
                            //loop to next images2 because all images from a list have now been moved and wont show up again
                            continue;
                        }
                    }
                }
            }
            //making the lists source the sorted and unlocked reward images
            myListView.FlowItemsSource = images;
        }

        //returns to mainpage
        private void backButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }

    //Listview requires lists of objects
    //Image is the stored image
    public class image
    {

        public string Image { get; set; }
    }

    //imagegroup is a list of images including the group name or title from all the images
    public class imageGroup : List<image>
    {
        public string Title { get; set; }
        public imageGroup(string title)
        {
            Title = title;
        }

        public IList<image> All { private set; get; }

    }
}