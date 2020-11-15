using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserPosts.Site.Models
{
    public class UserPostCountDataViewModel
    {
        public IEnumerable<UserPostCountData> NameUserNamePosts { get; set; }

        public UserPostCountDataViewModel(IEnumerable<UserPostCountData> nameUserNamePosts)
        {
            NameUserNamePosts = nameUserNamePosts;
        }
    }
}
