using System;
using System.Collections.Generic;
using MaintainIt_SP.StartupPages;
using Xamarin.Forms;

namespace MaintainIt_SP.Settings
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private async void LogOutClicked(object sender, EventArgs e)
        {
            var logout = await DisplayAlert("Log Out", "Are you sure you want to log out?","Log Out","Cancel");

            if(logout == true) 
            {
                await Navigation.PushModalAsync(new NavigationPage(new MainPage()));
            }
        }

        private void CPassClicked(object sender, EventArgs e)
        {
            //TODO Create a way to change password 

            //await Navigation.PushAsync(new ChangePasswordPage());
            throw new NotImplementedException();
        }
    }
}
