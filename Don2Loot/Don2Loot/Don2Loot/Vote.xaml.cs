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
        public Vote()
        {
            InitializeComponent();
        }
        async void backButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}