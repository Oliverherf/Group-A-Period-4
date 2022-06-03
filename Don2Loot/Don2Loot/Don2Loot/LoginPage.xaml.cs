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

        private async void Button_Clicked(object sender, EventArgs e)
        {
                if (string.IsNullOrEmpty(txtUserName.Text))
                {
                    DisplayAlert("Alert!", "All fields shoud be fill in!", "Go back");
                    return;
                }
                if (string.IsNullOrEmpty(txtEmail.Text))
                {
                    DisplayAlert("Alert!", "All fields shoud be fill in!", "Go back");
                    return;
                }

            if (txtUserName.Text.Length > 20 && txtUserName.Text.Length < 2)
                {
                    //DisplayAlert("Alert", txtUserName.MaxLength.ToString(), "ok");
                    DisplayAlert("Alert!", "Username must contain 2-20 characters", "Use a Grammar Check!");
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
                var contact = new Contact
                {
                    Email = txtEmail.Text,
                    Name = txtUserName.Text.ToUpper()
                };
                var mainPage = new MainPage();
                mainPage.BindingContext = contact;
                Navigation.InsertPageBefore(mainPage, this);    //inserting page before current page
                await Navigation.PopAsync();                    //popping current page off the navigation stack (Mainpage is now the main page/root page
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

    internal class Contact
    {
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
