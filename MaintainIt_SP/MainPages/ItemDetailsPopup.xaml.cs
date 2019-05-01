using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MaintainIt_SP.ItemsData;
using MaintainIt_SP.Services;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace MaintainIt_SP.MainPages
{
    public partial class ItemDetailsPopup
    {
        ObservableCollection<ItemSchedule> Schedule = new ObservableCollection<ItemSchedule>();

        public ItemDetailsPopup(ItemInstance item)
        {
            InitializeComponent();

            Notifications.ItemsSource = Schedule;

            ItemSelection();

            Location.SelectedItem = item.Location;
            ItemType.SelectedItem = item.ItemType;
            Manufacturer.SelectedItem = item.Manufacturer;
            ItemName.Text = item.ItemName;
            ItemDesc.Text = item.ItemDesc;
            DatePurchased.Date = item.DatePurchased.Date;

            SetMainSched(item);
        }

        public ItemInstance UpdatedItemDet;

        public void SaveItem()
        {
            ItemInstance itemInstance = new ItemInstance();
            itemInstance.Location = Location.SelectedItem.ToString();
            itemInstance.ItemType = ItemType.SelectedItem.ToString();
            itemInstance.Manufacturer = Manufacturer.SelectedItem.ToString();
            itemInstance.ItemName = ItemName.Text;
            itemInstance.ItemDesc = ItemDesc.Text;
            itemInstance.DatePurchased = DatePurchased.Date;
            UpdatedItemDet = itemInstance;
        }


        private async void ExitClicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(true);

        }

        public EventHandler UpdateItem;
        private async void SaveClicked(object sender, EventArgs e)
        {
            SaveItem();

            EventHandler handler = UpdateItem;
            handler?.Invoke(this, e);

            await PopupNavigation.Instance.PopAsync(true);

        }

        public void SetMainSched(ItemInstance item)
        {
            ItemData data = new ItemData();

            var date = DateTime.Now.Year;

            switch (item.ItemType)
            {
                case ("Refrigerator"):
                    foreach (string sched in data.FridgeSchedule)
                    {
                        Schedule.Add(new ItemSchedule
                        {
                            NotifyDate = GetCorrectDate(item),
                            Message = sched
                        });
                    }
                    break;

                default:
                    break;
            }
        }

        public string GetCorrectDate(ItemInstance item)
        {
            var date = DateTime.Now;

            return item.DatePurchased.AddMonths(6).AddYears(
                DateTime.Now.Year - item.DatePurchased.Year).ToShortDateString();


        }

        ItemData item = new ItemData();
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


    }
}
