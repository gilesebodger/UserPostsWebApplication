using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserPosts.Implentation.Model;

namespace UserPosts.Implentation.Services
{
    public interface IUserPostsService
    {
        Task<IEnumerable<UserPostData>> GetUserPosts();
    }
}
