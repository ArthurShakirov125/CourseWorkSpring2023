using CourseWorkSpring2023.Abstract;
using CourseWorkSpring2023.DataAccessLayer;
using CourseWorkSpring2023.Entities;
using CourseWorkSpring2023.Models.IndexViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CourseWorkSpring2023.Controllers
{
    public class PostsController : Controller
    {
        private PostsRepository postsManager;
        private ICrud<PostsTags> tagsManager;
        private UserManager<CustomUser> userManager;
        private RatingsRepository ratingsManager;


        public PostsController(PostsRepository postsManager,
            ICrud<PostsTags> tagsManager, UserManager<CustomUser> userManager,
            RatingsRepository ratingsManager)
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

        public async Task<IActionResult> Index(int days = 0, string filter = null)
        {
            CustomUser user = await GetUser();
            var model = new IndexViewModel();

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
                    var rawPosts = postsManager.GetList().OrderByDescending(p => p.Upvotes).Select(p => new PostViewModel(p));
                    DateTime DaysFromToday = DateTime.Today.AddDays(-days);

                    model.Posts = rawPosts.Where(p => p.Posted > DaysFromToday);
                    return View(model);
                case "new":
                    model.Posts = postsManager.GetList().OrderByDescending(p => p.Uploaded).Select(p => new PostViewModel(p));
                    return View(model);
                case "follow":
                    model.Posts = postsManager.GetFollowedPosts(user).Select(p => new PostViewModel(p));
                    return View(model);
                case "popular":
                    model.Posts = postsManager.GetList().OrderByDescending(p => p.Comments.Count).Select(p => new PostViewModel(p));
                    return View(model);
                default:
                    model.Posts = postsManager.GetList().Select(p => new PostViewModel(p));
                    return View(model);
            }
        }


        public IActionResult CommentsOfPost(int postId)
        {
            var comments = postsManager.GetPostsComments(postId);
            return View(comments);
        }

        [Authorize]
        public IActionResult CreatePost()
        {
            var model = new PostViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(PostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(CreatePost), model);
            }

            CustomUser user = await GetUser();

            var post = new Post()
            {
                Header = model.Header,
                Text = model.RawText,
                User = user,
                Downvotes = 0,
                Upvotes = 0,
                Uploaded = DateTime.Now,
            };

            postsManager.Create(post);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> ReadPost(int postId)
        {
            var model = new PostViewModel(postsManager.Read(postId));
            model.Comments = postsManager.GetPostsComments(postId);
            CustomUser user = await GetUser();

            model.UpvotedCommentsIds = ratingsManager.UsersUpvotes(user).Select(p => p.Id);
            model.DownvotedCommentsIds = ratingsManager.UsersDownvotes(user).Select(p => p.Id);
            model.ActiveUser = user;
            return View(model);
        }
    }
}
