using Licenses.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Licenses.Interfaces
{
    public interface IDatabase
    {
        Task<List<Apps>> GetAppsAsync();

        Task<Apps> GetAppAsync(int id);

        Task<int> SaveAppAsync(Apps App);

        Task<int> SaveAppAsync(IEnumerable<Apps> apps);

        Task<int> DeleteAppAsync(App App);
    }
}
