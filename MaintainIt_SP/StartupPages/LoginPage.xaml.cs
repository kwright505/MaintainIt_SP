using System;
using System.IO;
using System.Collections.Generic;
using SQLite;
using MaintainIt_SP.MainPages;
using Xamarin.Forms;
using Rg.Plugins.Popup.Services;

namespace MaintainIt_SP.StartupPages
{
    public partial class LoginPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void CancelClicked(object sender, EventArgs e)
        {
            ClosePopup();
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            //TODO check user credentials using SQL Database 

            //User checkuser = new User();
            //checkuser.Username = Username.Text;
            //checkuser.Password = PWOriginal.Text;


            //if (CheckTextBox(checkuser) == true & App.Database.CheckUser(checkuser) == true)
            //{
            //    //await DisplayAlert("Hi", "This is just to say Hello", "Hey");
            //    await Navigation.PushModalAsync(new NavigationPage(new DashboardPage()));
            //}
            //await PopupNavigation.Instance.PopAsync(true);
            ClosePopup();
            await Navigation.PushModalAsync(new NavigationPage(new DashboardPage()));

        }
        private async void ClosePopup()
        {
            await PopupNavigation.Instance.PopAsync(true);

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

            else
                return true;

        }
    }
}