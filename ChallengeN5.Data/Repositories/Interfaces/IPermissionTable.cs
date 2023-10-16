using ChallengeN5.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Data.Repositories.Interfaces
{
    public interface IPermissionTable<T> where T : class
    {
        Task<int> CountPermissions();
        Task<T> GetPermissionById(int id);
        Task<List<T>> GetPermissionsList();
        Task<List<T>> GetPermissionsFilter(int initial, int final);
    }
}
