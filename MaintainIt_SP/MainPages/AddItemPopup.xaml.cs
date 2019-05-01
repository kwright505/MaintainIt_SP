using System;
using MaintainIt_SP.Services;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MaintainIt_SP.ItemsData;
using System.Collections.Generic;
using MaintainIt_SP.MainPages;

namespace MaintainIt_SP.MainPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddItemPopup
    {
        public AddItemPopup(int loc)
        {
            InitializeComponent();

            switch (loc)
            {
                case 0:
                    Location.SelectedIndex = 0;
                    break;
                case 1:
                    Location.SelectedIndex = 1;
                    break;
                default:
                    Console.WriteLine("sorry bout that");
                    break;
            }

            ItemSelection();

        }

        ItemData item = new ItemData();
        List<string> mytypes = new List<string>();

        public string NewItemType { get; set; }

        public void ItemSelection()
        {
            if (Location.SelectedIndex == 1)
            {
                var itemlookup = item.GarageItemTypes;
                foreach (string itype in itemlookup)
                {
                    ItemType.Items.Add(itype);
                }
            }

            else 
            {
                var itemlookup = item.ItemTypes;
                foreach (string itype in itemlookup)
                {
                    ItemType.Items.Add(itype);
                }
            }
        }

        void Handle_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (Location.SelectedIndex == 1)
            {
                switch (ItemType.SelectedIndex)
                {
                    case -1:
                        Manufacturer.Items.Clear();
                        break;
                    case (0):
                        Manufacturer.Items.Clear();
                        break;
                    case (1):
                        Manufacturer.Items.Clear();
                        break;
                    case (2):
                        Manufacturer.Items.Clear();
                        break;
                    case (3):
                        Manufacturer.Items.Clear();
                        break;
                    case (4):
                        Manufacturer.Items.Clear();
                        PowerTools();
                        break;
                    default:
                        Manufacturer.Items.Clear();
                        break;
                }
            }

            else
            {
                switch (ItemType.SelectedIndex)
                {
                    case -1:
                        Manufacturer.Items.Clear();
                        break;
                    case (0):
                        Manufacturer.Items.Clear();
                        break;
                    case (1):
                        Manufacturer.Items.Clear();
                        Microwave();
                        break;

                    case (2):
                        Manufacturer.Items.Clear();
                        Oven();
                        break;

                    case (3):
                        Manufacturer.Items.Clear();
                        Fridge();
                        break;

                    default:
                        Manufacturer.Items.Clear();
                        break;
                }

            }
        }

        public void Microwave() 
        {
            var itemlookup = item.MicroManufacturers;
            foreach (string man in itemlookup)
            {
                Manufacturer.Items.Add(man);
            }

        }
        public void Oven()
        {
            var itemlookup = item.OvenManufacturers;
            foreach (string man in itemlookup)
            {
                Manufacturer.Items.Add(man);
            }
        }
        public void Fridge()
        {
            var itemlookup = item.FridgeManufacturers;
            foreach (string man in itemlookup)
            {
                Manufacturer.Items.Add(man);
            }
        }

        public void PowerTools()
        {
            var itemlookup = item.PowerToolsManufacturers;
            foreach (string man in itemlookup)
            {
                Manufacturer.Items.Add(man);
            }
        }

        public int checkDone;

        private async void ExitClicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(true);
                    
        }

        public ItemInstance NewItemDet = new ItemInstance();

        public void SaveItem()
        {
            ItemInstance itemInstance = new ItemInstance
            {
               Location = Location.SelectedItem.ToString(),
               ItemType = ItemType.SelectedItem.ToString(),
               Manufacturer = Manufacturer.SelectedItem.ToString(),
               ItemName = ItemName.Text,
               ItemDesc = ItemDesc.Text,
               DatePurchased = DatePurchased.Date
            };

            NewItemDet = itemInstance;

            NotifyMe();

            ClearItem();

        }

        private void NotifyMe() 
        {
            ItemData data = new ItemData();
            MaintenenceNotifications notify = new MaintenenceNotifications();

            switch (NewItemDet.ItemType)
            {
                case ("Refrigerator"):
                    foreach (string sched in data.FridgeSchedule)
                    {
                        notify.NewNotification(sched, NewItemDet.DatePurchased.AddMonths(6).AddYears(
                            DateTime.Now.Year - NewItemDet.DatePurchased.Year));
                    }
                    break;

                default:
                    break;
            }
        }


        public void ClearItem()
        {
            ItemType.SelectedItem = null;
            Manufacturer.SelectedItem = null;
            ItemName.Text = "";
            ItemDesc.Text = "";
            DatePurchased.Date = DateTime.Today;
        }

        public void ClearItemDetails(ItemInstance item) 
        {
            item.ItemType = "";
            item.Manufacturer = "";
            item.Location = "";
            item.ItemName = "";
            item.ItemDesc = "";
        }

        public EventHandler NewItemSave;
        private async void AddClicked(object sender, EventArgs e)
        {
            if (ItemType.SelectedIndex== -1 || Manufacturer.SelectedIndex == -1)
            {
                await DisplayAlert("Oops", "Please fill in all Areas", "OK");
            }
            else
            {
                SaveItem();

                EventHandler handler = NewItemSave;
                if (handler != null) 
                {
                    handler?.Invoke(this, e);
                }

                else
                    await DisplayAlert("oops", "handler is null", "OK");

                await DisplayAlert("New Item!", "Created new Item", "OK");

                //ClearItemDetails(NewItemDet);
                await PopupNavigation.Instance.PopAsync(true);
            }
        }

    }
}