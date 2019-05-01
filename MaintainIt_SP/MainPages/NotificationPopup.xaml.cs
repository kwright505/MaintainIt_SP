using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MaintainIt_SP.ItemsData;
using MaintainIt_SP.Services;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace MaintainIt_SP.MainPages
{
    public partial class NotificationPopup
    {
        public NotificationPopup()
        {
            InitializeComponent();

        }

        public async void DoneClicked(object sender, EventArgs e) 
        {
            SaveReminder();

            await DisplayAlert("New Reminder!", "Created new Reminder", "OK");
            await PopupNavigation.Instance.PopAsync(true);
        }



        private void SaveReminder()
        {
            Reminder myReminder = new Reminder
            {
                ReminderName = ReminderName.Text,
                ReminderDesc = ReminderDesc.Text,
                ReminderDate = ReminderDate.Date.ToShortDateString()
            };

            ItemData data = new ItemData();

            data.Reminders.Add(myReminder);

            foreach (Reminder reminder in data.Reminders) 
            {
                Console.WriteLine(reminder.ReminderName);
            }

        }

        public void ExitClicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync(true);
        }

    }
}
