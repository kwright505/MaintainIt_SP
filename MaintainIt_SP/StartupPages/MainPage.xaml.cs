using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using Rg.Plugins.Popup.Services;

namespace MaintainIt_SP.StartupPages
{
    public partial class MainPage : ContentPage
    {
        //string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "UserDB.db3");

        public MainPage()
        {
            InitializeComponent();

        }


        private async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            //Console.WriteLine("Going to Sign up page");
            //Console.WriteLine(App.Database.GetUsers());
            await PopupNavigation.Instance.PushAsync(new SignUpPage());
        }

        private async void OnLogInButtonClicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new LoginPage());
        }
    }
}
