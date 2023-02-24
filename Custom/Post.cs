using System;
using System.Collections;
using System.Collections.Generic;

namespace CourseWorkSpring2023.Custom
{
    public class Post
    {
        public int Id { get; set; }
        public string Header { get; set; }

        public string Text { get; set; }

        public int Upvotes { get; set; }

        public int Downvotes { get; set; }

        public DateTime Posted { get; set; }

        public List<PostsTags> Tags { get; set; }

        public CustomUser User { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
