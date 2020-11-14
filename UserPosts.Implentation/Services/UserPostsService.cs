using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserPosts.Implentation.Repository;
using UserPosts.Implentation.Model;
using System.Linq;

namespace UserPosts.Implentation.Services
{
    public class UserPostsService : IUserPostsService
    {
        private readonly IUserPostsRepository _userPostsRepository;

        public UserPostsService(IUserPostsRepository userPostsRepository)
        {
            _userPostsRepository = userPostsRepository;
        }

        public async Task<IEnumerable<UserPostData>> GetUserPosts()
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
    }
}
