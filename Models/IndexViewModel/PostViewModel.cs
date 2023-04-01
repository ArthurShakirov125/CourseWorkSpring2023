using CourseWorkSpring2023.Entities;
using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CourseWorkSpring2023.Models.IndexViewModel
{
    public class PostViewModel
    {
        public PostViewModel()
        {

        }
        public PostViewModel(Post post)
        {
            Id = post.Id;
            Header = post.Header;
            RawText = post.Text;
            Upvotes = post.Upvotes;
            Downvotes = post.Downvotes;
            Posted = post.Uploaded;
            Tags = post.Tags;
            Author = post.User;
            IsHidden = post.IsHidden;
            Comments = post.Comments;

            ProcessedText = new HtmlString(RawText);
        }

        public int Id { get; }

        [Required(ErrorMessage = "Заголовок обязателен")]
        [Display(Name = "Заголовок")]
        [StringLength(10, ErrorMessage = "Ограничение на 250 символов")]
        public string Header { get; set; }

        [StringLength(250, ErrorMessage = "Ограничение на 250 символов")]
        public string RawText { get; set; }

        public HtmlString ProcessedText { get; set; }

        public int Upvotes { get; set; }

        public int Downvotes { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Posted { get; set; }

        public IEnumerable<PostsTags> Tags { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public bool IsHidden { get; }
        public CustomUser Author { get; set; }

        public int Rating
        {
            get { return Upvotes - Downvotes; }
        }

        public CustomUser ActiveUser { get; set; }

        public int CommentsCount
        {
            get
            {
                return Comments != null ? Comments.Count() : 0;
            }
        }

        public IEnumerable<int> UpvotedCommentsIds { get; set; }

        public IEnumerable<int> DownvotedCommentsIds { get; set; }

    }
}
