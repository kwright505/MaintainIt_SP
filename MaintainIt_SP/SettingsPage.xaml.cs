using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MaintainIt_SP
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

        private async void CPassClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChangePasswordPage(), false);
        }
    }
}
