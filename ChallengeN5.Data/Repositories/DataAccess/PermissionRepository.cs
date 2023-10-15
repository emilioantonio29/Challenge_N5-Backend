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
    public class PermissionRepository : IPermission<Permission>
    {
        private ChallengeN5DbContext _context;
        public PermissionRepository(ChallengeN5DbContext context) 
        {
            _context = context;
        }

        public Task<Permission> GetPermission(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Permission>> GetPermissions()
        {
            throw new NotImplementedException();
        }

        public Task<List<Permission>> GetPermissions(int initial, int final)
        {
            throw new NotImplementedException();
        }

        public Task<Permission> GetPermissionType(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> ModifyPermission(Permission data)
        {
            throw new NotImplementedException();
        }
    }
}
