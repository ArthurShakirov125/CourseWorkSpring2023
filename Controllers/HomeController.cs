using CourseWorkSpring2023.Abstract;
using CourseWorkSpring2023.Constants;
using CourseWorkSpring2023.Custom;
using CourseWorkSpring2023.Data.Migrations;
using CourseWorkSpring2023.DataAccessLayer;
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
        private PostsRepository postsManager;
        private ICrud<PostsTags> tagsManager;
        private UserManager<CustomUser> userManager;
        private RatingsRepository ratingsManager;

        public HomeController(PostsRepository postsManager, ICrud<PostsTags> tagsManager, UserManager<CustomUser> userManager, RatingsRepository ratingsManager)
        {
            this.postsManager = postsManager;
            this.tagsManager = tagsManager;
            this.userManager = userManager;
            this.ratingsManager = ratingsManager;
        }

        private async Task<CustomUser> GetUser()
        {
            return await userManager.GetUserAsync(User);
        }


        public async Task<IActionResult> Index(string filter = null)
        {
            CustomUser user = await GetUser();
            var model = new HomeViewModel();

            if (user != null)
            {
                model.ActiveUser = user;
                model.UpvotedPostsIds = ratingsManager.UsersUpvotes(user).Select(p => p.Id);
                model.DownvotedPostsIds = ratingsManager.UsersDownvotes(user).Select(p => p.Id);
            }
            else
            {
                model.ActiveUser = null;
                model.UpvotedPostsIds = null;
                model.DownvotedPostsIds = null;
            }

            switch (filter)
            {
                case "top":
                    model.Posts = postsManager.GetList().OrderByDescending(p => p.Upvotes).Select(p => new PostViewModel(p));
                    return View(model);
                case "new":
                    model.Posts = postsManager.GetList().OrderByDescending(p => p.Uploaded).Select(p => new PostViewModel(p));
                    return View(model);
                default:
                    model.Posts = postsManager.GetList().Select(p => new PostViewModel(p));
                    return View(model);
            }
        }

        public async Task<IActionResult> UserMain()
        {
            var user = await GetUser();

            var model = new UserViewModel(user);
            return View();
        }

        public IActionResult CreatePost()
        {
            var model = new PostViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(PostViewModel model)
        {
            CustomUser user = await GetUser();

            var post = new Post()
            {
                Header = model.Header,
                Text = model.Text,
                User = user,
                Downvotes = 0,
                Upvotes = 0,
                Uploaded = DateTime.Now,
            };

            postsManager.Create(post);
            return RedirectToAction(nameof(Index));
        }

        public async Task<string> GetAjax()
        {
            /// сделать обработку 
            /// разработать наш протокол
            /// 
            int id = 0;
            if (Request.Form.ContainsKey("Id"))
            {
               id  = int.Parse(Request.Form["Id"]);
            }
            CustomUser user = await GetUser();

            switch (Request.Form["Action"])
            {
                case "upvote":
                    {
                        ratingsManager.Upvote(id, user);
                        return "200";
                    }
                case "downvote":
                    {
                        ratingsManager.Downvote(id, user);
                        return "200";
                    }
                case "remove_downvote":
                    {
                        ratingsManager.RemoveDownvote(id, user);
                        return "200";
                    }
                case "remove_upvote":
                    {
                        ratingsManager.RemoveUpvote(id, user);
                        return "200";
                    }
                case "downvote_and_remove_upvote":
                    {
                        ratingsManager.DownvoteAndRemoveUpvote(id, user);
                        return "200";
                    }
                case "upvote_and_remove_downvote":
                    {
                        ratingsManager.UpvoteAndRemoveDownvote(id, user);
                        return "200";
                    }
                case "comment":
                    {
                        int postId = int.Parse(Request.Form["PostId"]);
                        postsManager.AddComment(user, postId, Request.Form["Text"]);
                        return "200";
                    }

                default:
                    return "400";
            }
        }


        public async Task<IActionResult> Post(int postId)
        {
            var model = new PostViewModel(postsManager.Read(postId));
            CustomUser user = await GetUser();

            model.UpvotedCommentsIds = ratingsManager.UsersUpvotes(user).Select(p => p.Id);
            model.DownvotedCommentsIds = ratingsManager.UsersDownvotes(user).Select(p => p.Id);
            model.ActiveUser = user;
            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
