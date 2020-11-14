using System;
using System.Collections.Generic;
using System.Text;

namespace UserPosts.Implentation.Model
{
    public class UserPostData
    {
        public UserRaw User { get; }
        public IEnumerable<PostRaw> Posts { get; }

        public UserPostData(UserRaw user, IEnumerable<PostRaw> posts)
        {
            User = user;
            Posts = posts;
        }
    }
}
