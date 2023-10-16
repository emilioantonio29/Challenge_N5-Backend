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

        public async Task<List<PermissionTable>> GetPermissionsFilter(int initial, int limit)
        {
            return await _context.PermissionsTable.OrderBy(pt => pt.Date).Skip(initial).Take(limit).ToListAsync();

        }

        public async Task<List<PermissionTable>> GetPermissionsListBySearchValue(string searchValue)
        {
            if (int.TryParse(searchValue, out int id))
            {
                return await _context.PermissionsTable.Where(p => p.Id == id).ToListAsync();
            }
            else
            {
                searchValue = searchValue.ToLower();
                return await _context.PermissionsTable
                    .Where(p => p.Name.ToLower().Contains(searchValue) ||
                                p.Lastname.ToLower().Contains(searchValue) ||
                                p.PermissionTypeId.ToString().Contains(searchValue))
                    .ToListAsync();
            }
        }
    }
}
