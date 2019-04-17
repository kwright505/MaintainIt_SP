using System;
using SQLite;

namespace MaintainIt_SP
{
    public class HomeItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
