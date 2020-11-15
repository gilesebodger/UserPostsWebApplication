using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserPosts.Site.Models
{
    public class PostViewModel
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Body { get; set; }

        public PostViewModel(int id, string title, string body)
        {
            Id = id;
            Title = title;
            Body = body;
        }




    }
}
