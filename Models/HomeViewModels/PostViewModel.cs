using CourseWorkSpring2023.Custom;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseWorkSpring2023.Models.HomeViewModels
{
    public class PostViewModel
    {
        public PostViewModel()
        {

        }
        public PostViewModel(Post post)
        {
            Header = post.Header;
            Text = post.Text;
            Upvotes = post.Upvotes;
            Downvotes = post.Downvotes;
            Posted = post.Posted;
            Tags = post.Tags;
            Author = post.User;

        }

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

        public CustomUser Author { get; set; }

        public int Rating
        {
            get { return Upvotes - Downvotes; }
        }


    }
}
