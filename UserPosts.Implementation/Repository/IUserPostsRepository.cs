﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserPosts.Implementation.Model;

namespace UserPosts.Implementation.Repository
{
    public interface IUserPostsRepository
    {
        Task<UserRaw> GetUser(int userId);
        Task<IEnumerable<PostRaw>> GetUserPosts(int userId);
        Task<IEnumerable<PostRaw>> GetAllPosts();
        Task<IEnumerable<UserRaw>> GetAllUsers();
    }


}
