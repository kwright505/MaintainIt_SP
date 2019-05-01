using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MaintainIt_SP.ItemsData;
using MaintainIt_SP.Services;
using Rg.Plugins.Popup.Services;
using Syncfusion.SfCalendar.XForms;

using Xamarin.Forms;

namespace MaintainIt_SP.MainPages
{
    public partial class CalendarPage : ContentPage
    {
        public ObservableCollection<Reminder> NewReminder = new ObservableCollection<Reminder>();
        NotificationPopup myReminder = new NotificationPopup();

        public CalendarPage()
        {
            InitializeComponent();

            RemindersList.ItemsSource = NewReminder;

            NewReminder.Clear();

            foreach (Reminder reminders in data.Reminders)
            {
                DisplayNewCell(reminders);
            }

        }

        ItemData data = new ItemData();
        public void RefreshClicked(object sender, EventArgs e) 
        {
            DisplayAlert("Reminders", "Refreshing....", "OK");
            foreach (Reminder reminders in data.Reminders)
            {
                DisplayNewCell(reminders);
            }
        }


        public void TestClicked(object sender, EventArgs e)
        {
            Reminder rem = new Reminder
            {
                ReminderName = "adnfj;nwjql;fq",
                ReminderDesc = "afmkal;df",
                ReminderDate = DateTime.Now.ToShortDateString()
            };

            DisplayNewCell(rem);
        }

        private async void AddReminderClicked(object sender, EventArgs e) 
        {
            await PopupNavigation.Instance.PushAsync(new NotificationPopup());
        }

        public void DisplayNewCell(Reminder r)
        {
            NewReminder.Add(new Reminder
            {
                ReminderName = r.ReminderName,
                ReminderDesc = r.ReminderDesc,
                ReminderDate = r.ReminderDate
            });
        }
    }
}
