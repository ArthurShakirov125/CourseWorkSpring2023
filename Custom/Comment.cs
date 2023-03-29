using CourseWorkSpring2023.Abstract;
using Microsoft.AspNetCore.Html;
using System;

namespace CourseWorkSpring2023.Custom
{
    public class Comment : UploadableContent
    {
        public string Text { get; set; }
        public Post Post { get; set; }

        public HtmlString ProcessedText
        {
            get
            {
                return new HtmlString(Text);
            }
        }

        public int Rating
        {
            get { return Upvotes - Downvotes; }
        }


    }
}
