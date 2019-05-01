using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MaintainIt_SP.Services;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using System.Threading.Tasks;
using MaintainIt_SP.MainPages;

namespace MaintainIt_SP.MainPages
{
    public partial class MyGaragePage : ContentPage
    {
        ObservableCollection<ItemInstance> GarageItemsList = new ObservableCollection<ItemInstance>();
        AddItemPopup addItemPopup = new AddItemPopup(0);
        CarPopup carPopup = new CarPopup();

        public MyGaragePage()
        {
            InitializeComponent();



            //GarageItems.ItemsSource = GarageItemsList;
        }

        public void DisplayNewGarageCell(ItemInstance itemInstance)
        {
            GarageItemsList.Add(new ItemInstance
            {
                Location = itemInstance.Location,
                //ItemType = itemInstance.ItemType,
                //Manufacturer = itemInstance.Manufacturer,
                ItemName = itemInstance.ItemName,
                ItemDesc = itemInstance.ItemDesc,
                DatePurchased = itemInstance.DatePurchased
            });
        }

        public void DisplayNewCarCell(CarInstance carInstance) 
        {
            GarageItemsList.Add(new CarInstance
            {
                ItemType = carInstance.ItemType,
                Manufacturer = carInstance.Manufacturer,
                Model = carInstance.Model,
                VIN = carInstance.VIN,
                Year = carInstance.Year
            });
        }


        public void SavingNewGarageItem(object s, EventArgs e)
        { 
            DisplayNewGarageCell(addItemPopup.NewItemDet);
        }

        public void SavingCarItem(object s, EventArgs e)
        {
            DisplayNewCarCell(carPopup.NewCarDet);
        }

        private async void AddGarageItemClicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Add Item", "Cancel", null, "Car", "Garage Item");
            if (action == "Garage Item")
            {
                addItemPopup.NewItemSave += SavingNewGarageItem;
                await PopupNavigation.Instance.PushAsync(new AddItemPopup(1));
            }
            else
            {
             carPopup.NewItemSave = new EventHandler(SavingCarItem);
             await PopupNavigation.Instance.PushAsync(new CarPopup());
            }
        }

        ItemInstance selectedGarageItem;
        CarInstance carInstanceItem;

        async void OnTapEventAsyncCar(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null) return;
            carInstanceItem = e.Item as CarInstance;
            CarDetailsPopup itemToUpdate = new CarDetailsPopup(carInstanceItem);
            //itemToUpdate.UpdateItem += new EventHandler(UpdatingItem);

          await PopupNavigation.Instance.PushAsync(itemToUpdate);

        }

        async void OnTapEventAsyncGarage(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null) return;
            selectedGarageItem = e.Item as ItemInstance;
            ItemDetailsPopup itemToUpdate = new ItemDetailsPopup(selectedGarageItem);
            //itemToUpdate.UpdateItem += new EventHandler(UpdatingItem);

          await PopupNavigation.Instance.PushAsync(itemToUpdate);

        }

        void DeleteClicked(object sender, EventArgs e)
        {
            GarageItemsList.Remove(selectedGarageItem);
        }
    }
}
