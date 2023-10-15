using ChallengeN5.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Data.Repositories.Interfaces
{
    internal interface IPermission<T>
    {
        Task<List<T>> GetPermissions();
        Task<List<T>> GetPermissions(int initial, int final);
        Task<T> GetPermission(int id);
        Task<int> ModifyPermission(Permission data);
        Task<T> GetPermissionType(int id);
    }
}
