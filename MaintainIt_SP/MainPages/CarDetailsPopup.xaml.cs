using System;
using System.Collections.Generic;
using MaintainIt_SP.Services;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace MaintainIt_SP.MainPages
{
    public partial class CarDetailsPopup
    {
        public CarDetailsPopup(CarInstance carInstance)
        {
            InitializeComponent();
        }

        private async void ExitClicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(true);

        }

        private async void SaveClicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(true);

        }

    }
}
