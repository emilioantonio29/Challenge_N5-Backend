using ChallengeN5.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Data.Repositories.Interfaces
{
    internal interface IUser <T>
    {
        Task<T> GetUser(string username);
    }
}
