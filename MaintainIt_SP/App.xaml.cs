using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLitePCL;
using System.IO;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MaintainIt_SP
{
    public partial class App : Application
    {

        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzYzMDJAMzEzNjJlMzQyZTMwb3JaeDFocnhMQzFDTjJsYlU1WklROStHaDk3UjZDNDIrTGJUaVhoYjFXbz0=");

            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        static UserDatabase database;

        public static UserDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new UserDatabase(Path.Combine(
                    System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "UserDB.db3"));
                }

                return database;
            }
        }

        static HomeInventory homeInventory;

        public static HomeInventory HomeInventory
        {
            get
            {
                if (homeInventory == null)
                {
                    database = new UserDatabase(Path.Combine(
                    System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "HomeDB.db3"));
                }

                return homeInventory;
            }
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }


}
