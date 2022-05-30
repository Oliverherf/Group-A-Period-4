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
        }

        private void collectionPageButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CollectionPage());
        }
    }
}