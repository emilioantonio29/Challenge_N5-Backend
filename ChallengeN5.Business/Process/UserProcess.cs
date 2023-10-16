using ChallengeN5.Business.Models;
using ChallengeN5.Data.Repositories.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Business.Process
{
    public class UserProcess
    {
        private UserRepository _userRepository;

        public UserProcess(UserRepository userRepository) 
        {
            _userRepository = userRepository;
        }
        public async Task<int> UserTest(UserViewModel data)
        {
            Console.WriteLine("UserTest");
            await Task.Delay(2000);

            var res = await _userRepository.GetUserByUsername(data.username);

            return 1;
        }
    }
}
