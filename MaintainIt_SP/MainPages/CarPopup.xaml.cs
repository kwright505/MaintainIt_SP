using System;
using System.Collections.Generic;
using DaleNewman;
using MaintainIt_SP.ItemsData;
using MaintainIt_SP.Services;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace MaintainIt_SP.MainPages
{
    public partial class CarPopup
    {
        public CarPopup()
        {
            InitializeComponent();
            ItemType.SelectedItem = "Car";
            SetUpManufacturers();
        }

        ItemData item = new ItemData();
        public void SetUpManufacturers()
        {
            var itemlookup = item.CarManufacturer;
            foreach (string itype in itemlookup)
            {
                Manufacturer.Items.Add(itype);
            }
        }
        
        private async void ExitClicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(true);

        }

        public CarInstance NewCarDet;

        public void SaveItem()
        {
            CarInstance carInstance = new CarInstance
            {
                ItemType = ItemType.SelectedItem.ToString(),
                VIN = VINNumber.Text,
                Manufacturer = Manufacturer.SelectedItem.ToString(),
                Model = Model.Text,
                Year = Year.Text,
                DatePurchaced = DatePurchased.Date
            };

            NewCarDet = carInstance;
        }

        public EventHandler NewItemSave;
        private async void AddClicked(object sender, EventArgs e)
        {
            SaveItem();

            EventHandler handler = NewItemSave;

            if (handler != null)
                handler?.Invoke(this, e);
            else
                await DisplayAlert("oops", "handler is null", "OK");

            await PopupNavigation.Instance.PopAsync(true);

        }

        public void TestVINClicked(object sender, EventArgs e) 
        { 
            if (Vin.IsValid(VINNumber.Text) == false) 
            {
                DisplayAlert("Vin Number", "VIN number is not valid", "Ok"); 
            }

            else
            {
                Year.Text = Vin.GetModelYear(VINNumber.Text).ToString();
                Manufacturer.SelectedItem = Vin.GetWorldManufacturer(VINNumber.Text);
            }
        }
    }
}
