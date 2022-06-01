using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Don2Loot
{
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
                return;
            }

            if (!IsAllLetters(txtUserName.Text))
            {
                DisplayAlert("Alert!", "Username should contain only letters", "Use a Grammar Check!");
                return;
            }

            if (!IsValidEmail(txtEmail.Text))
            {
                DisplayAlert("Alert!", "Email is not valid", "Use a Grammar Check!");
                return;
            }
            //System.Diagnostics.Debug.WriteLine("Success");
            Navigation.PushAsync(new MainPage());
        }
        public bool IsAllLetters(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsLetter(c))
                    return false;
            }
            return true;
        }
        public bool IsValidEmail(string email)
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
