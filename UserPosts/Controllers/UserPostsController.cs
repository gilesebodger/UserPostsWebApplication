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

        //[Route("userposts")]
        public async Task<IActionResult> Index()
        {
            var userPosts = await _userPostsService.GetUserPosts();
            var modelData = new List<UserPostsData>();
            foreach (var item in userPosts)
            {
                modelData.Add(
                    new UserPostsData(
                        item.User.Id,
                        item.User.Name,
                        item.User.UserName,
                        item.Posts.Count()
                        )
                    );
            }

            var viewModel = new UserPostsDataViewModel(modelData);

            return View(viewModel);
        }

        public async Task<IActionResult> AllUsers()
        {
            var userPosts = await _userPostsService.GetUserPosts();
            var modelData = new List<UserPostsData>();
            foreach (var item in userPosts)
            {
                modelData.Add(
                    new UserPostsData(
                        item.User.Id,
                        item.User.Name, 
                        item.User.UserName, 
                        item.Posts.Count()
                        )
                    );
            }

            var viewModel = new UserPostsDataViewModel(modelData);

            return View(viewModel);
        }
    }
}
