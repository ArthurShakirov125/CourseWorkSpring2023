using CourseWorkSpring2023.Constants;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CourseWorkSpring2023.Componentes
{
    public class PostsFilterViewComponent : ViewComponent
    {
        public PostsFilterViewComponent() { }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
