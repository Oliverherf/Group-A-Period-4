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