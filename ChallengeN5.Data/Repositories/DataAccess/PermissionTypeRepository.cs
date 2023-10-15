using ChallengeN5.Data.ChallengeN5_DbContext;
using ChallengeN5.Data.Entities;
using ChallengeN5.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Data.Repositories.DataAccess
{
    public class PermissionTypeRepository : IPermission<PermissionType>
    {
        private ChallengeN5DbContext _context;
        public PermissionTypeRepository(ChallengeN5DbContext context) 
        {
            _context = context;
        }

        public Task<PermissionType> GetPermission(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PermissionType>> GetPermissions()
        {
            throw new NotImplementedException();
        }

        public Task<List<PermissionType>> GetPermissions(int initial, int final)
        {
            throw new NotImplementedException();
        }

        // Only Method needed in this repository
        public Task<PermissionType> GetPermissionType(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> ModifyPermission(Permission data)
        {
            throw new NotImplementedException();
        }
    }
}
