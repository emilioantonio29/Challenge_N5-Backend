﻿using ChallengeN5.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Data.Repositories.Interfaces
{
    public interface IPermission<T> where T : class
    {
        Task<int> UpdatePermission(T data);
    }
}
