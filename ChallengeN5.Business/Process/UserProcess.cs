using ChallengeN5.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Business.Process
{
    public class UserProcess
    {
        public UserProcess() 
        { 
            
        }
        public async Task<int> UserTest()
        {
            Console.WriteLine("UserTest");
            await Task.Delay(2000);
            return 1;
        }
    }
}
