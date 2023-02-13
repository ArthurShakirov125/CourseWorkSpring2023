using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CourseWorkSpring2023.Custom
{
    public class CustomUser : IdentityUser
    {
        public string NickName { get; set; }

        public string AvatarImgName { get; set; }

        public byte[] AvatarImg { get; set; }

        public DateTime RegistrationDay { get; set; }

        public IEnumerable<Post> Posts { get; set; }
    }
}
