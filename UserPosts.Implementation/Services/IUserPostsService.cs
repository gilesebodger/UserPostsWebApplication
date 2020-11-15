using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserPosts.Implementation.Model;

namespace UserPosts.Implementation.Services
{
    public interface IUserPostsService
    {
        Task<IEnumerable<UserPostData>> GetUserAndPostCounts();

        Task<UserPostData> GetSpecificUserPostData(int userId);
    }
}
