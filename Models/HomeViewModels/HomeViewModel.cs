using CourseWorkSpring2023.Custom;
using System.Collections;
using System.Collections.Generic;

namespace CourseWorkSpring2023.Models.HomeViewModels
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {

        }

        public IEnumerable<Post> Posts { get; set; }
    }
}
