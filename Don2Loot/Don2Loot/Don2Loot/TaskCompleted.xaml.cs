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
    public partial class TaskCompleted : ContentPage
    {
        public TaskCompleted()
        {
            InitializeComponent();
        }

        async void backButton(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}