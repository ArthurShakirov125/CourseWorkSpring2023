using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseWorkSpring2023.Custom
{
    public class UsersPostsRates
    {
        public int Id { get; set; }
        public CustomUser CustomUser { get; set; }
        public Post Post { get; set; }
        public bool isUpvote { get; set; }
    }
}
