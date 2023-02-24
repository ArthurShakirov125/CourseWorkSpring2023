using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseWorkSpring2023.Custom
{
    public class UsersPostsRates
    {
        public CustomUser CustomUser { get; set; }

        public Post Post { get; set; }
    }
}
