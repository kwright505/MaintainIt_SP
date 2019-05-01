using System;
using MaintainIt_SP.MainPages;
using Plugin.LocalNotifications;

namespace MaintainIt_SP.Services
{
    public class MaintenenceNotifications
    {
        public MaintenenceNotifications()
        {
        }
        
        public void NewNotification(string sched, DateTime time)
        {
            //CrossLocalNotifications.Current.Show("MaintainIt Maintenance Reminder",
                //sched, 101, time);

            CrossLocalNotifications.Current.Show("MaintainIt Maintenance Reminder",
                sched, 101, DateTime.Now.AddSeconds(10));

        }

        public void TestNotification()
        {
            CrossLocalNotifications.Current.Show("MaintainIt Maintenance Reminder", 
                "Thanks for Chosing MaintainIt!", 101, DateTime.Now.AddSeconds(5));
        }
    }
}
