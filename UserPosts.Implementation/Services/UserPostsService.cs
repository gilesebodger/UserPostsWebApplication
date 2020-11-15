using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserPosts.Implementation.Repository;
using UserPosts.Implementation.Model;
using System.Linq;

namespace UserPosts.Implementation.Services
{
    public class UserPostsService : IUserPostsService
    {
        private readonly IUserPostsRepository _userPostsRepository;

        public UserPostsService(IUserPostsRepository userPostsRepository)
        {
            _userPostsRepository = userPostsRepository;
        }

        public async Task<IEnumerable<UserPostData>> GetUserAndPostCounts()
        {
            var users = await _userPostsRepository.GetAllUsers();
            var posts = await _userPostsRepository.GetAllPosts();
            var postsLookup = posts.GroupBy(p => p.UserId).ToDictionary(k => k.Key, v => v.ToList());

            var returnValue = new List<UserPostData>();

            foreach (var u in users)
            {
                postsLookup.TryGetValue(u.Id, out var pList);
                if (pList == null)
                {
                    pList = new List<PostRaw>();
                }
                returnValue.Add(new UserPostData(u, pList));
            }

            return returnValue;

        }

        public async Task<UserPostData> GetSpecificUserPostData(int userId)
        {
            var user = await _userPostsRepository.GetUser(userId);
            var userPosts = await _userPostsRepository.GetUserPosts(userId);           

            return new UserPostData(user, userPosts);
        }
    }
}
