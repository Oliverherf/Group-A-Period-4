using DLToolkit.Forms.Controls;
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
    public partial class CollectionPage : ContentPage
    {
        public CollectionPage()
        {
            InitializeComponent();
            FlowListView.Init();
            this.BindingContext = this;

            List<imageGroup> Groups = new List<imageGroup> {
                new imageGroup("Anime")
                {
                    new image{Image = "Attack_titan"},
                    new image{Image = "Gojo"},
                    new image{Image = "Kaneki"}
                }
            };
            myListView.FlowItemsSource = Groups;
        }

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