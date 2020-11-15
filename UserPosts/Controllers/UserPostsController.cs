using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserPosts.Implementation.Services;
using UserPosts.Site.Models;

namespace UserPosts.Site.Controllers
{
    public class UserPostsController : Controller
    {
        private readonly IUserPostsService _userPostsService;

        public UserPostsController(IUserPostsService userPostsService)
        {
            _userPostsService = userPostsService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userPosts = await _userPostsService.GetUserAndPostCounts();
            var modelData = new List<UserPostCountData>();
            foreach (var item in userPosts)
            {
                modelData.Add(
                    new UserPostCountData(
                        item.User.Id,
                        item.User.Name,
                        item.User.UserName,
                        item.Posts.Count()
                        )
                    );
            }

            var viewModel = new UserPostCountDataViewModel(modelData);

            return View(viewModel);
        }

        [HttpGet]
        [Route("userposts/{userId}")]
        public async Task<IActionResult> Detail(int userId)
        {
            var userPostData = await _userPostsService.GetSpecificUserPostData(userId);
            var modelData = new UserPostDataViewModel
            {
                Name = userPostData.User.Name,
                UserName = userPostData.User.UserName,
                UserId = userPostData.User.Id,
                AddressStreet = userPostData.User.Address.Street,
                AddressSuite = userPostData.User.Address.Suite,
                AddressCity = userPostData.User.Address.City,
                AddressZipcode = userPostData.User.Address.Zipcode,
                AddressLat = userPostData.User.Address.Geo.Lat,
                AddressLng = userPostData.User.Address.Geo.Lng,
                Phone = userPostData.User.Phone,
                Website = userPostData.User.Website,
                CompanyName = userPostData.User.Company.Name,
                CompanyCatchPhrase = userPostData.User.Company.CatchPhrase,
                CompanyBs = userPostData.User.Company.BS
            };

            var postsViewModel = new List<PostViewModel>();

            foreach (var p in userPostData.Posts)
            {
                postsViewModel.Add(new PostViewModel(p.Id, p.Title, p.Body));
            }

            modelData.Posts = postsViewModel;

            return View(modelData);
        }
    }
}
