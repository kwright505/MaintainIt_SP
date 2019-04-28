using System;
using SQLite;

namespace MaintainIt_SP.Services
{

    public class CarInstance
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string VIN { get; set; }
        public string ItemType { get; set; }
    }
}
