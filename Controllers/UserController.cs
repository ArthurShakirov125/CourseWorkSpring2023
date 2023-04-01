using CourseWorkSpring2023.Abstract;
using CourseWorkSpring2023.DataAccessLayer;
using CourseWorkSpring2023.Entities;
using CourseWorkSpring2023.Models;
using CourseWorkSpring2023.Models.IndexViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CourseWorkSpring2023.Controllers
{
    public class UserController : Controller
    {
        private PostsRepository postsManager;
        private UserManager<CustomUser> userManager;
        private FollowersRepository followersManager;

        public UserController(PostsRepository postsManager, UserManager<CustomUser> userManager,FollowersRepository followersManager)
        {
            this.postsManager = postsManager;
            this.userManager = userManager;
            this.followersManager = followersManager;
        }

        private async Task<CustomUser> GetUser()
        {
            return await userManager.GetUserAsync(User);
        }

        [Authorize]
        public async Task<IActionResult> UserMainPage()
        {
            var user = await GetUser();

            var model = new UserViewModel(user);
            model.Posts = postsManager.GetUsersPosts(user).Select(p => new PostViewModel(p));
            return View(model);
        }

        public async Task<IActionResult> UserPage(string userName)
        {
            var user = await userManager.FindByNameAsync(userName);
            UserViewModel model = new UserViewModel(user);

            return View(model);
        }

        public async Task<IActionResult> FollowTest(string userId)
        {
            var follower = await GetUser();

            followersManager.FollowUser(follower.Id, userId);

            return RedirectToAction("Index");

        }
    }
}
