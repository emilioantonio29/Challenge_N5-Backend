using ChallengeN5.Data.ChallengeN5_DbContext;
using ChallengeN5.Data.Entities;
using ChallengeN5.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Data.Repositories.DataAccess
{
    public class PermissionTableRepository : IPermissionTable<PermissionTable>
    {
        private ChallengeN5DbContext _context;

        public PermissionTableRepository(ChallengeN5DbContext context) 
        {
            _context = context;
        }

        public async Task<int> CountPermissions()
        {
            return await _context.PermissionsTable.CountAsync();
        }

        public async Task<PermissionTable> GetPermissionById(int id)
        {
            return await _context.PermissionsTable.FirstOrDefaultAsync(pt => pt.Id == id);
        }

        public async Task<List<PermissionTable>> GetPermissionsList()
        {
            return await _context.PermissionsTable.ToListAsync();
        }

        public async Task<List<PermissionTable>> GetPermissionsFilter(int initial, int final)
        {
            return await _context.PermissionsTable.OrderBy(pt => pt.Date).Skip(initial).Take(final).ToListAsync();
        }
    }
}
