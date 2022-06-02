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
    public partial class StorePage : ContentPage
    {
        public StorePage()
        {
            InitializeComponent();
            FlowListView.Init();
            this.BindingContext = this;

            List<crate> crates = new List<crate>
            {
                new crate{Name="beniscrate", Cost=100, Image="crate"},
                new crate{Name="fortnite", Cost=250, Image="crate"},
                new crate{Name="hextech", Cost=250, Image="crate"}
            };
            storePageView.FlowItemsSource = crates;
        }

        private void backButton(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }

    public class crate
    {
        private string name;
        private int cost;
        private string image;

        public string Name { get; set; }
        public int Cost { get; set; }
        public string Image { get; set; }
    }

}