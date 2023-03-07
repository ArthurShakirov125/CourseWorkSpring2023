using CourseWorkSpring2023.Custom;
using System;

namespace CourseWorkSpring2023.Abstract
{
    public class UploadableContent
    {
        public int Id { get; set; }
        public CustomUser User { get; set; }
        public int Upvotes { get; set; }
        public int Downvotes { get; set; }
        public DateTime Uploaded { get; set; }
        public bool IsHidden { get; set; } = false;
    }
}
