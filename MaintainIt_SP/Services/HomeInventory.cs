using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace MaintainIt_SP
{
    public class HomeInventory
    {
        static SQLiteAsyncConnection database;

        public HomeInventory(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<HomeItem>().Wait();
        }


        public Task<List<HomeItem>> GetItems()
        {
            return database.Table<HomeItem>().ToListAsync();
        }

        public Task<int> SaveItem(HomeItem homeItem)
        {
            if (homeItem.ID != 0)
            {
                return database.UpdateAsync(homeItem);
            }

            else
            {
                return database.InsertAsync(homeItem);
            }
        }

        public Task<int> DeleteItem(HomeItem homeItem)
        {
            return database.DeleteAsync(homeItem);
        }
    }
}
