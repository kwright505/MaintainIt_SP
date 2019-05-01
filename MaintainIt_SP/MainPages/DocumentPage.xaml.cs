using System;
using System.Collections.Generic;
using System.Net.Http;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace MaintainIt_SP.MainPages
{
    public partial class DocumentPage : ContentPage
    {
        private MediaFile _mediaFile;

        public DocumentPage()
        {
            InitializeComponent();
        }

        public async void ChoosePhotoClicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Oops", "Cant choose photo", "OK");
            }

            _mediaFile = await CrossMedia.Current.PickPhotoAsync();

            if (_mediaFile == null)
                return;

            LocalPathName.Text = _mediaFile.Path;
            FileImage.Source = ImageSource.FromStream(() =>
            {
                return _mediaFile.GetStream();
            });
        }

        public async void TakePhotoClicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || 
                !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Oops", "Camera not Available", "Ok");
                return;
            }

            _mediaFile = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "myImage.jpg"
            });


            if (_mediaFile == null)
                return;

            LocalPathName.Text = _mediaFile.Path;
            FileImage.Source = ImageSource.FromStream(() =>
            {
                return _mediaFile.GetStream();
            });
        }

        public async void UploadPhotoClicked(object sender, EventArgs e)
        {
            var content = new MultipartFormDataContent();

            content.Add(new StreamContent(_mediaFile.GetStream()),
                "\"file\"",
                $"\"{_mediaFile.Path}\"");

            var httpClient = new HttpClient();

            var uplaodServiceBaseAddress = @"https://localhost:5001";

            var httpResponseMessage = await httpClient.PostAsync(uplaodServiceBaseAddress, content);

            LocalPathName.Text = await httpResponseMessage.Content.ReadAsStringAsync();
        }
    }
}
