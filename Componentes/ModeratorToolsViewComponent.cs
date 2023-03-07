using Microsoft.AspNetCore.Mvc;

namespace CourseWorkSpring2023.Componentes
{
    public class ModeratorToolsViewComponent : ViewComponent
    {
        public ModeratorToolsViewComponent() {}

        public IViewComponentResult Invoke(int id)
        {
            return View(id);
        }
    }
}
