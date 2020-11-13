﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserPosts.Implentation.Model;

namespace UserPosts.Implentation.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUser(int userId);
    }


}