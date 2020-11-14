using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserPosts.Implentation.Services;

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
            var users = await _userPostsService.GetUserPosts();

            return View();
        }
    }
}
