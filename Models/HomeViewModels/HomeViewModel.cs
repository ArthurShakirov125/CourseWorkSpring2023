using CourseWorkSpring2023.Abstract;
using CourseWorkSpring2023.Custom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CourseWorkSpring2023.Models.HomeViewModels
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
        }

        public IEnumerable<PostViewModel> Posts { get; set; }

        public CustomUser ActiveUser { get; set; }

        public IEnumerable<int> UpvotedPostsIds { get; set; }

        public IEnumerable<int> DownvotedPostsIds { get; set; }
    }
}
