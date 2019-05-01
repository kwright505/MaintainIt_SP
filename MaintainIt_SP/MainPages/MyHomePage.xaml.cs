using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MaintainIt_SP.ItemsData;
using MaintainIt_SP.Services;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace MaintainIt_SP.MainPages
{
    public partial class MyHomePage : ContentPage
    {
        ObservableCollection<ItemInstance> NewItem = new ObservableCollection<ItemInstance>();
        AddItemPopup addItemPopup = new AddItemPopup(0);
        ItemData savedata = new ItemData();

        public MyHomePage()
        {
            InitializeComponent();

            itemList.ItemsSource = NewItem;

            foreach (ItemInstance item in savedata.itemInstances)
            {
                NewItem.Add(item);
            }
        }

        private void TestClicked(object sender, EventArgs e)
        {
           
        }

        public void DisplayNewCell(ItemInstance itemInstance) 
        {
            NewItem.Clear();

            savedata.itemInstances.Add(new ItemInstance
            {
                Location = itemInstance.Location,
                ItemType = itemInstance.ItemType,
                Manufacturer = itemInstance.Manufacturer,
                ItemName = itemInstance.ItemName,
                ItemDesc = itemInstance.ItemDesc,
                DatePurchased = itemInstance.DatePurchased
            });

            foreach(ItemInstance item in savedata.itemInstances) 
            {
                NewItem.Add(item);
            }


        }

        public void SavingNewItem(object s, EventArgs e)
        {
            DisplayNewCell(addItemPopup.NewItemDet);
            DisplayAlert("New Notification", "New " + addItemPopup.NewItemDet.ItemType
                + " Maintenence Notification for " 
                + addItemPopup.NewItemDet.DatePurchased.AddMonths(6).AddYears(DateTime.Now.Year - addItemPopup.NewItemDet.DatePurchased.Year).ToShortDateString(),
                 "OK");
        }

        private async void AddHomeItemClicked(object sender , EventArgs e) 
        {
            addItemPopup.NewItemSave = new EventHandler(SavingNewItem);

            await PopupNavigation.Instance.PushAsync(addItemPopup);
        }



        public void UpdatingItem(object s, EventArgs e)
        {
            NewItem.Remove(selectedItem);

            DisplayNewCell(itemToUpdate.UpdatedItemDet);

        }

        ItemInstance selectedItem;
        ItemDetailsPopup itemToUpdate;

        async void OnTapEventAsync(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null) return;
            selectedItem = e.Item as ItemInstance;
            itemToUpdate = new ItemDetailsPopup(selectedItem);
            itemToUpdate.UpdateItem += new EventHandler(UpdatingItem);


            await PopupNavigation.Instance.PushAsync(itemToUpdate);

        }

        void DeleteClicked(object sender, EventArgs e)
        {
            NewItem.Remove(selectedItem);
        }

    }
}
