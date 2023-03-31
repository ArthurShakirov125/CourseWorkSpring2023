using CourseWorkSpring2023.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CourseWorkSpring2023.Entities
{
    public class Post : UploadableContent
    {
        public string Header { get; set; }

        public string Text { get; set; }

        public List<PostsTags> Tags { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
