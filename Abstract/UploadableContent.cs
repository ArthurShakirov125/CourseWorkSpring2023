using CourseWorkSpring2023.Entities;
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

        public string UserAvatarPath
        {
            get
            {
                string path = @"/Users/UsersAvatarsImages/" + User.AvatarImgName;
                return path;
            }
        }
    }
}
