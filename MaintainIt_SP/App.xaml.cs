using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLitePCL;
using System.IO;
using MaintainIt_SP.StartupPages;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MaintainIt_SP
{
    public partial class App : Application
    {

        public App()
        {
            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzYzMDJAMzEzNjJlMzQyZTMwb3JaeDFocnhMQzFDTjJsYlU1WklROStHaDk3UjZDNDIrTGJUaVhoYjFXbz0=");

            InitializeComponent();

            MainPage = new MainPage();
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
