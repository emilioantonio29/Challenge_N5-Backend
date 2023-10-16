using ChallengeN5.Data.ChallengeN5_DbContext;
using ChallengeN5.Data.Entities;
using ChallengeN5.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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

        public async Task<int> UpdatePermission(Permission data)
        {
            _context.Entry(data).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
