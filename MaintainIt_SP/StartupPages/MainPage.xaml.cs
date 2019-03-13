using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;

namespace MaintainIt_SP
{
    public partial class MainPage : ContentPage
    {
        string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "UserDB.db3");

        public MainPage()
        {
            InitializeComponent();

        }


        private async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Going to Sign up page");
            Console.WriteLine(App.Database.GetUsers());
            await Navigation.PushAsync(new SignUpPage() { BindingContext = new User() });
        }

        private async void OnLogInButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }
}
