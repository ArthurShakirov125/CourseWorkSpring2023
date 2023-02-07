using CourseWorkSpring2023.Constants;
using CourseWorkSpring2023.Data.Custom;
using CourseWorkSpring2023.Models.AdminControllerViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CourseWorkSpring2023.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class AdminController : Controller
    {
        UserManager<CustomUser> userManager;
        RoleManager<IdentityRole> roleManager;

        public AdminController(UserManager<CustomUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }


        // GET: AdminController
        public IActionResult Index() => View(roleManager.Roles.ToList());

        // GET: AdminController/Details/5
        public ActionResult UserList()
        {
            return View(userManager.Users.ToList());
        }

        // GET: AdminController/Create
        public ActionResult Create() => View();

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(string name)
        {
                if (!string.IsNullOrEmpty(name))
                {
                    var result =  await roleManager.CreateAsync(new IdentityRole(name));
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                
                return View(name);
        }

        // GET: AdminController/Edit/5
        public async Task<ActionResult> EditUserRole(string userid)
        {
            RoleViewModel model = new RoleViewModel();

            CustomUser user = await userManager.FindByIdAsync(userid);
            if(user != null)
            {
                model.UserEmail = user.Email;
                model.UserId = userid;
                model.UserRoles = await userManager.GetRolesAsync(user);
                model.AllRoles = roleManager.Roles.ToList();
            }
            
            return View(model);
        }

        public async Task<ActionResult> AddRole(string roleid, string userid)
        {
            var user = await userManager.FindByIdAsync(userid);
            var roleToAdd = await roleManager.FindByIdAsync(roleid);

            if(user != null && roleToAdd != null)
            {
                var userRoles = await userManager.GetRolesAsync(user);
                await userManager.RemoveFromRolesAsync(user, userRoles);

                await userManager.AddToRoleAsync(user, roleToAdd.Name);

                return RedirectToAction(nameof(UserList));
            }
            return RedirectToAction(nameof(UserList));
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            if(role != null)
            {
                await roleManager.DeleteAsync(role);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
