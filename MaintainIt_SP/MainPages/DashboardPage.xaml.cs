using System;
using System.Collections.Generic;

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
            await Navigation.PushAsync(new SettingsPage());
        }

        public async void GoToMyHome(object sender, EventArgs e)
        {
            var myHome = new MyHomePage();
            await Navigation.PushAsync(new TabControllerPage(myHome));
        }


        public async void GoToMyGarage(object sender, EventArgs e)
        {
            var myGarage = new MyGaragePage();
            await Navigation.PushAsync(new TabControllerPage(myGarage));
        }

        public async void GoToCalendar(object sender, EventArgs e)
        {
            var calendar = new CalendarPage();
            await Navigation.PushAsync(new TabControllerPage(calendar));
        }

        public async void GoToDocuments(object sender, EventArgs e)
        {
            var docs = new DocumentPage();
            await Navigation.PushAsync(new TabControllerPage(docs));
        }
    }
}
