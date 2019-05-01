using System;
using SQLite;

namespace MaintainIt_SP.Services
{
    public class ItemInstance
    {
        public string ItemName { get; set; }
        public string ItemDesc { get; set; }
        public DateTime DatePurchased { get; set; }
        public string Location { get; set; }
        public int UserID { get; set; }
        public string Manufacturer { get; set; }
        public string ItemType { get; set; }
    }
}