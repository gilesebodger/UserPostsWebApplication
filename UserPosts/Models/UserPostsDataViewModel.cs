using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserPosts.Site.Models
{
    public class UserPostsDataViewModel
    {
        public IEnumerable<UserPostsData> NameUserNamePosts { get; set; }

        public UserPostsDataViewModel(IEnumerable<UserPostsData> nameUserNamePosts)
        {
            NameUserNamePosts = nameUserNamePosts;
        }
    }
}
