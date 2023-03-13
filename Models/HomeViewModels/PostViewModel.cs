using CourseWorkSpring2023.Custom;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CourseWorkSpring2023.Models.HomeViewModels
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
            Text = post.Text;
            Upvotes = post.Upvotes;
            Downvotes = post.Downvotes;
            Posted = post.Uploaded;
            Tags = post.Tags;
            Author = post.User;
            IsHidden = post.IsHidden;
            Comments = post.Comments;
        }

        public int Id { get; }

        [Required]
        [Display(Name = "Заголовок")]
        public string Header { get; set; }

        [Required]
        [StringLength(240, ErrorMessage = "Ограничение на 240 символов")]
        public string Text { get; set; }

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
