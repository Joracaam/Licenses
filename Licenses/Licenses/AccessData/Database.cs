using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Licenses.Models;
using Licenses.Interfaces;

namespace Licenses.AccessData
{
    public class Database: IDatabase
    {
        readonly SQLiteAsyncConnection database;

        public Database(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Apps>().Wait();
        }

        public Task<List<Apps>> GetAppsAsync()
        {
            //Get all Apps.
            return database.Table<Apps>().ToListAsync();
        }

        public Task<Apps> GetAppAsync(int id)
        {
            // Get a specific App.
            return database.Table<Apps>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveAppAsync(Apps App)
        {
            if (App.Id != 0)
            {
                // Update an existing App.
                return database.UpdateAsync(App);
            }
            else
            {
                // Save a new App.
                return database.InsertAsync(App);
            }
        }

        public Task<int> DeleteAppAsync(App App)
        {
            // Delete a App.
            return database.DeleteAsync(App);
        }

        public Task<int> SaveAppAsync(IEnumerable<Apps> apps)
        {
            int count = 0;
            foreach (var item in apps)
            {
                if (item.Id != 0)
                {
                    // Update an existing App.
                    database.UpdateAsync(item);
                    count++;
                }
                else
                {
                    // Save a new App.
                    database.InsertAsync(item);
                    count++;
                }
            }

            return Task.FromResult(count);
        }
    }
}
