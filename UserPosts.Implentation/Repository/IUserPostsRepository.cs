using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserPosts.Implentation.Model;

namespace UserPosts.Implentation.Repository
{
    public interface IUserPostsRepository
    {
        Task<UserRaw> GetUser(int userId);
        Task<IEnumerable<PostRaw>> GetAllPosts();
        Task<IEnumerable<UserRaw>> GetAllUsers();
    }


}
