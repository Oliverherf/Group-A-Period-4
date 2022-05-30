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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {

            if (txtUserName.Text.Length >= 20)
            {
                //DisplayAlert("Alert", txtUserName.MaxLength.ToString(), "ok");
                DisplayAlert("Alert!", "Username is too long", "Use a Grammar Check!");
            }
            /*else
            {
                DisplayAlert("Alert", txtUserName.Text.Length.ToString(), "ok");
            }*/
        }
        static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}