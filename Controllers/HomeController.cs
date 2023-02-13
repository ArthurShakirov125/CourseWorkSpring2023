using CourseWorkSpring2023.Abstract;
using CourseWorkSpring2023.Constants;
using CourseWorkSpring2023.Custom;
using CourseWorkSpring2023.Models;
using CourseWorkSpring2023.Models.HomeViewModels;
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
        private ICrud<Post> Crud { get; set; }
        private HomeViewModel model;
        public HomeController(ICrud<Post> crud)
        {
            Crud = crud;
        }

        public IActionResult Index()
        {   
            model = new HomeViewModel();
            model.Posts = Crud.GetList().Take(20);

            return View(model);
        }

















        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
