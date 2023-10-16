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
    public class PermissionTypeRepository : IPermissionType<PermissionType>
    {
        private ChallengeN5DbContext _context;

        public PermissionTypeRepository(ChallengeN5DbContext context) 
        {
            _context = context;
        }

        public async Task<PermissionType> GetPermissionTypeById(int id)
        {
            return await _context.PermissionTypes.FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
