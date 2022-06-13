﻿using SignaturePad.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
                    DisplayAlert("Alert!", "All fields shoud be fill in!", "Ok");
                    return;
                }
                if (string.IsNullOrEmpty(txtEmail.Text))
                {
                    DisplayAlert("Alert!", "All fields shoud be filled in!", "Ok");
                    return;
                }  

            if (txtUserName.Text.Length > 20 && txtUserName.Text.Length < 2)
                {
                    //DisplayAlert("Alert", txtUserName.MaxLength.ToString(), "ok");
                    DisplayAlert("Alert!", "Username must contain 2-20 characters", "Ok");
                    return;
                }

                if (!IsAllLetters(txtUserName.Text))
                {
                    DisplayAlert("Alert!", "Username should contain only letters", "Ok");
                    return;
                }

                if (!IsValidEmail(txtEmail.Text))
                {
                    DisplayAlert("Alert!", "Email is not valid", "Ok");
                    return;
                }
                
                 try
                 {
                    var image = await signature.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Png);
                    var mStream = (MemoryStream)image;
                    byte[] data = mStream.ToArray();
                    string base64Val = Convert.ToBase64String(data);
                    lblBase64Value.Text = base64Val;
                    imgSignature.Source = ImageSource.FromStream(() => mStream);

                 }
                 catch (Exception ex)
                 {
                    await DisplayAlert("Error", ex.Message.ToString(), "Ok");
                 }


            //System.Diagnostics.Debug.WriteLine("Success");
            var contact = new Contact
                {
                    Email = txtEmail.Text,
                    Name = txtUserName.Text.ToUpper()
                };
                var mainPage = new MainPage();
                mainPage.BindingContext = contact;
                //Navigation.InsertPageBefore(mainPage, this);    //inserting page before current page
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
