using System;
using SQLite;

namespace MaintainIt_SP.Services
{

    public class CarInstance : ItemInstance
    {
        public string Model { get; set; }
        public string Year { get; set; }
        public string VIN { get; set; }
        public DateTime DatePurchaced { get; set; }
    }
}
