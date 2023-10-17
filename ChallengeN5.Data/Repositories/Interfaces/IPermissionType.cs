using ChallengeN5.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Data.Repositories.Interfaces
{
    public interface IPermissionType<T> where T : class
    {
        Task<List<T>> GetPermissionsList();

        Task<T> GetPermissionTypeById(int id);
    }
}
