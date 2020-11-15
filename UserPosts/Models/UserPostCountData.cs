using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserPosts.Site.Models
{
    public class UserPostCountData
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public int PostCount { get; set; }

        public UserPostCountData(int userId, string name, string username, int postCount)
        {
            UserId = userId;
            Name = name;
            UserName = username;
            PostCount = postCount;
        }
    }
}
