using System;
using System.IO;
using System.Collections.Generic;
using SQLite;

using Xamarin.Forms;

namespace MaintainIt_SP
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            //TODO check user credentials using SQL Database 

            User checkuser = new User();
            checkuser.Username = Username.Text;
            checkuser.Password = PWOriginal.Text;


            if (CheckTextBox(checkuser) == true & App.Database.CheckUser(checkuser) == true)
            {
                //await DisplayAlert("Hi", "This is just to say Hello", "Hey");
                await Navigation.PushModalAsync(new NavigationPage(new DashboardPage()));
            }

        }

        public bool CheckTextBox(User user)
        {
            if (Username.Text == "" || PWOriginal.Text == "")
            {
                DisplayAlert("Sorry!", "Username or Password Incorrect", "OK");

                Username.Text = "Username";
                PWOriginal.Text = "";

                return false;
            }

            if (Username.Text == "Username" || PWOriginal.Text == "********")
            {
                DisplayAlert("Sorry!", "Username or Password Incorrect", "OK");

                return false;
            }

            if (App.Database.CheckUser(user) == false)
            {
                DisplayAlert("Sorry!", "Username or Password Incorrect", "OK");

                return false;
            }

            else
                return true;

        }
    }
}