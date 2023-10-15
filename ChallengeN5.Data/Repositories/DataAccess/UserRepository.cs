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
    public class UserRepository : IUser<User>
    {
        private ChallengeN5DbContext _context;
        public UserRepository(ChallengeN5DbContext context) 
        {
            _context = context;
        }

        public Task<User> GetUser(string username)
        {
            throw new NotImplementedException();
        }
    }
}
