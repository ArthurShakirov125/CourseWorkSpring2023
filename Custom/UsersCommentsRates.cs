using System.Collections.Generic;

namespace CourseWorkSpring2023.Custom
{
    public class UsersCommentsRates
    {
        public int Id { get; set; }
        public CustomUser CustomUser { get; set; }

        public Comment Comments { get; set; }
    }
}
