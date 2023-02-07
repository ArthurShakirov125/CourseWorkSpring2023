using CourseWorkSpring2023.Constants;
using CourseWorkSpring2023.Data.Custom;
using CourseWorkSpring2023.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        UserManager<CustomUser> userManager;
        RoleManager<IdentityRole> roleManager;
        public HomeController(RoleManager<IdentityRole> roleManager, UserManager<CustomUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            // await roleManager.CreateAsync(new IdentityRole("Admin"));

            /* var user = new IdentityUser()
             {
                 UserName = "Gura@mail.com",
                 Email = "Gura@mail.com"
             };

             await userManager.CreateAsync(user, "!Qwerty1"); */

            var users = userManager.Users.ToList();
            
            return View(users);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
