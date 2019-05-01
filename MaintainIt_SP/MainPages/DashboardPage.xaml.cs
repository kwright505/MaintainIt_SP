using System;
using System.Collections.Generic;
using MaintainIt_SP.Settings;
using Xamarin.Forms;

namespace MaintainIt_SP.MainPages
{
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            InitializeComponent();
        }

        public async void SettingsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new SettingsPage()));
        }

        public async void GoToMyHome(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TabControllerPage(new MyHomePage()));
        }


        public async void GoToMyGarage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TabControllerPage(new MyGaragePage()));
        }

        public async void GoToCalendar(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TabControllerPage(new CalendarPage()));
        }

        public async void GoToDocuments(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TabControllerPage(new DocumentPage()));
        }
    }
}
