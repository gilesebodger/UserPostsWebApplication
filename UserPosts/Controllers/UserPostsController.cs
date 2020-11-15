using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserPosts.Implentation.Services;
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
            var modelData = new UserPostDataViewModel();

            modelData.Name = userPostData.User.Name;
            modelData.UserName = userPostData.User.UserName;
            modelData.UserId = userPostData.User.Id;
            modelData.AddressStreet = userPostData.User.Address.Street;
            modelData.AddressSuite = userPostData.User.Address.Suite;
            modelData.AddressCity = userPostData.User.Address.City;
            modelData.AddressZipcode = userPostData.User.Address.Zipcode;
            modelData.AddressLat = userPostData.User.Address.Geo.Lat;
            modelData.AddressLng = userPostData.User.Address.Geo.Lng;
            modelData.Phone = userPostData.User.Phone;
            modelData.Website = userPostData.User.Website;
            modelData.CompanyName = userPostData.User.Company.Name;
            modelData.CompanyCatchPhrase = userPostData.User.Company.CatchPhrase;
            modelData.CompanyBs = userPostData.User.Company.BS;

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
