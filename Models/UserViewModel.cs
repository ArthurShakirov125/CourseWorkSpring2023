using CourseWorkSpring2023.Custom;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace CourseWorkSpring2023.Models
{
    public class UserViewModel
    {
        public UserViewModel(CustomUser user)
        {
            UserName = user.UserName;
            NickName = user.NickName;
            AvatarImgName = user.AvatarImgName;
            RegistrationDay = user.RegistrationDay;
            Posts = user.Posts;
            Comments = user.Comments;
        }

        public string UserName { get; set; }

        public string NickName { get; set; }

        public string AvatarImgName { get; set; }

        public byte[] AvatarImg { get; set; }

        public DateTime RegistrationDay { get; set; }

        public List<Post> Posts { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
