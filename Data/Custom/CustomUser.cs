using Microsoft.AspNetCore.Identity;
using System;

namespace CourseWorkSpring2023.Data.Custom
{
    public class CustomUser : IdentityUser
    {
        public string NickName { get; set; }

        public string AvatarImgName { get; set; }

        public byte[] AvatarImg { get; set; }

        public DateTime RegistrationDay { get; set; }
    }
}
