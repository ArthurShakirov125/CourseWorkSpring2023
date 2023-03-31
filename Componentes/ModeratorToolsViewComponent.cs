using CourseWorkSpring2023.Entities;
using CourseWorkSpring2023.Models.Moderator;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace CourseWorkSpring2023.Componentes
{
    public class ModeratorToolsViewComponent : ViewComponent
    {
        public ModeratorToolsViewComponent() {}

        public IViewComponentResult Invoke(string ContentType, int Id)
        {
            var model = new ModeratorToolsViewModel()
            {
                ContentType = ContentType,
                Id = Id
            };
            return View(model);
        }
    }
}
