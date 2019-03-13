using System;
using SQLite;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MaintainIt_SP
{
    public class UserDatabase
    {
        static SQLiteAsyncConnection database;

        public UserDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<User>().Wait();
        }

        public Task<List<User>> GetUsers()
        {
            return database.Table<User>().ToListAsync();
        }

        public Task<int> SaveUser(User user)
        {
            if (user.Username != "")
            {
                return database.UpdateAsync(user);
            }

            else
            {
                return database.InsertAsync(user);
            }
        }

        public Task<int> DeleteUser (User user)
        {
            return database.DeleteAsync(user);
        }

        public bool CheckUser(User user)
        {
            string query = "SELECT [Username], [Password] FROM [User] WHERE " +
            	"[Username = " + user.Username + "AND Password = " + user.Password + "]";
            if (database.QueryAsync<User>(query) == null)
            {
                return false;
            }

            else
            {
                return true;
            }
        }
    }
}
