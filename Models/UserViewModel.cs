using CourseWorkSpring2023.Entities;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using CourseWorkSpring2023.Models.HomeViewModels;
using System.Linq;
using System.ComponentModel.DataAnnotations;

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
            Comments = user.Comments;
            Id = user.Id;
          //  Followers = user.Followers;
        }

        public string Id { get; set; }

        public string UserName { get; set; }
        public string NickName { get; set; }

        public string AvatarImgName { get; set; }

        public DateTime RegistrationDay { get; set; }

        public IEnumerable<PostViewModel> Posts { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        public string AvatarImagePath
        {
            get
            {
                string path = @"/Users/UsersAvatarsImages/" + AvatarImgName;
                return path;
            }
        }
    }
}
