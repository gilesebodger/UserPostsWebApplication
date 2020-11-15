using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserPosts.Site.Models
{
    public class UserPostDataViewModel
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public int UserId { get; internal set; }
        public string AddressStreet { get; set; }
        public string AddressSuite { get; set; }
        public string AddressCity { get; set; }
        public string AddressZipcode { get; set; }
        public double AddressLat { get; set; }
        public double AddressLng { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCatchPhrase { get; set; }
        public string CompanyBs { get; set; }
        public IEnumerable<PostViewModel> Posts { get; set; }
    }
}
