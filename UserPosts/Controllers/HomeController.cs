//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using UserPosts.Implentation.Repository;
//using UserPosts.Models;

//namespace UserPosts.Controllers
//{
//    public class HomeController : Controller
//    {
//        private readonly ILogger<HomeController> _logger;
//        private readonly IUserPostsRepository _userRepo;

//        public HomeController(ILogger<HomeController> logger, IUserPostsRepository userRepo)
//        {
//            _logger = logger;
//            _userRepo = userRepo;
//        }

//        public async Task<IActionResult> Index()
//        {
//            var u = await _userRepo.GetUser(1);

//            var ps = await _userRepo.GetAllPosts();

//            var us = await _userRepo.GetAllUsers();

//            return View();
//        }

//        public IActionResult Privacy()
//        {
//            return View();
//        }

//        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//        public IActionResult Error()
//        {
//            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//        }
//    }
//}
