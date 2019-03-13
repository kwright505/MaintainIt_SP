using System;
using System.Collections.Generic;
using System.IO;
using SQLite;
using MaintainIt_SP;
using Xamarin.Forms;

namespace MaintainIt_SP
{
    public partial class SignUpPage : ContentPage
    {

        public SignUpPage()
        {
            InitializeComponent();
        }

        private async void OnDoneButtonClicked(object sender, EventArgs e)
        {
            // TODO create setup pages for new users 
            if (CheckNewUserCred() == true)
            {

                var userItem = (User)BindingContext;
                await App.Database.SaveUser(userItem);
                await DisplayAlert("User Created", "user created for " + userItem.FirstName + " " + userItem.LastName + ".", "OK");

                await Navigation.PushModalAsync(new NavigationPage(new DashboardPage()));
            }
        }

        public bool CheckNewUserCred()
        {
            var userItem = (User)BindingContext;

            if (FirstName.Text == "" || Username.Text == "" || PWOriginal.Text == "" || PWConfirm.Text == "")
            {
                DisplayAlert("User not Created!", "Please fill in all fields", "OK");

                return false;
            }

            if (FirstName.Text == "First Name?" || Username.Text == "Choose a Username" || LastName.Text == "Last Name?"
            || PWOriginal.Text == "Password" || PWConfirm.Text == "Confirm Password")
            {
                DisplayAlert("User not created!", "Please fill in all fields", "OK");

                return false;
            }

            if (PWOriginal.Text != PWConfirm.Text)
            {
                DisplayAlert("Alert", "Passwords do not match", "OK");

                PWOriginal.Text = "";
                PWConfirm.Text = "";

                return false;
            }

            else
            {
                return true;
            }

        }
    }
}
