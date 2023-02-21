using CourseWorkSpring2023.Abstract;
using CourseWorkSpring2023.Constants;
using CourseWorkSpring2023.Custom;
using CourseWorkSpring2023.Data.Migrations;
using CourseWorkSpring2023.Models;
using CourseWorkSpring2023.Models.HomeViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CourseWorkSpring2023.Controllers
{
    public class HomeController : Controller
    {
        private ICrud<Post> postsManager;
        private ICrud<PostsTags> tagsManager;
        private UserManager<CustomUser> userManager;

        public HomeController(ICrud<Post> postsManager, ICrud<PostsTags> tagsManager, UserManager<CustomUser> userManager)
        {
            this.postsManager = postsManager;
            this.tagsManager = tagsManager;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index(string filter = null)
        {
            CustomUser user = await userManager.GetUserAsync(User);
            var model = new HomeViewModel();
            model.ActiveUser = user;

            switch (filter)
            {
                case "top":
                    model.Posts = postsManager.GetList().OrderBy(p => p.Upvotes).Select(p => new PostViewModel(p));
                    return View(model);
                case "new":
                    model.Posts = postsManager.GetList().OrderBy(p => p.Posted).Select(p => new PostViewModel(p));
                    return View(model);
                default:
                    model.Posts = postsManager.GetList().Select(p => new PostViewModel(p));
                    return View(model);
            }
        }

        public IActionResult CreatePost()
        {
            var model = new PostViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(PostViewModel model)
        {
            CustomUser user = await userManager.GetUserAsync(User);

            var post = new Post()
            {
                Header = model.Header,
                Text = model.Text,
                User = user,
                Downvotes = 0,
                Upvotes = 0,
                Posted = DateTime.Now,
            };

            postsManager.Create(post);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult GetAjax()
        {
            string name = Request.Form["Name"];
            string a = Request.Form["Value"];
            return Json("200");
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
