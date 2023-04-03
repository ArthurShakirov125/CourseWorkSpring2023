using CourseWorkSpring2023.Abstract;
using CourseWorkSpring2023.Constants;
using CourseWorkSpring2023.Entities;
using CourseWorkSpring2023.Data.Migrations;
using CourseWorkSpring2023.DataAccessLayer;
using CourseWorkSpring2023.Models;
using CourseWorkSpring2023.Models.IndexViewModel;
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
        private UserManager<CustomUser> userManager;
        private RatingsRepository ratingsManager;
        private ContentRepository contentManager;
        private CommentsRepository commentsManager;

        public HomeController(PostsRepository postsManager, UserManager<CustomUser> userManager, 
            RatingsRepository ratingsManager, ContentRepository contentManager, 
            CommentsRepository commentsRepository)
        {
            this.postsManager = postsManager;
            this.userManager = userManager;
            this.ratingsManager = ratingsManager;
            this.contentManager = contentManager;
            this.commentsManager = commentsRepository;
        }

        private async Task<CustomUser> GetUser()
        {
            return await userManager.GetUserAsync(User);
        }

        public async Task<JsonResult> GetAjax()
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
                        return Json(new { reply = 200 });
                    }
                case "downvote":
                    {
                        ratingsManager.Downvote(id, user);
                        return Json(new { reply = 200 });
                    }
                case "remove_downvote":
                    {
                        ratingsManager.RemoveDownvote(id, user);
                        return Json(new { reply = 200 });
                    }
                case "remove_upvote":
                    {
                        ratingsManager.RemoveUpvote(id, user);
                        return Json(new { reply = 200 });
                    }
                case "downvote_and_remove_upvote":
                    {
                        ratingsManager.DownvoteAndRemoveUpvote(id, user);
                        return Json(new { reply = 200 });
                    }
                case "upvote_and_remove_downvote":
                    {
                        ratingsManager.UpvoteAndRemoveDownvote(id, user);
                        return Json(new { reply = 200 });
                    }
                case "comment":
                    {
                       /* int postId = int.Parse(Request.Form["PostId"]);
                        int commentId = postsManager.AddComment(user, postId, Request.Form["Text"]);
                        return Json(new { reply = 200, commentId = commentId.ToString(), username = user.NickName });*/
                       return Json(new { reply = 200 });
                    }
                case "hide":
                    {
                        contentManager.Hide(id);
                        return Json(new { reply = 200 });
                    }
                case "unhide":
                    {
                        contentManager.UnHide(id);
                        return Json(new { reply = 200 });
                    }
                case "delete_post":
                    {
                        postsManager.Delete(id);
                        return Json(new { reply = 200 });
                    }
                case "delete_comment":
                    {
                        commentsManager.Delete(id);
                        return Json(new { reply = 200 });
                    }
                default:
                    return Json(new { reply = 400 });
            }
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
