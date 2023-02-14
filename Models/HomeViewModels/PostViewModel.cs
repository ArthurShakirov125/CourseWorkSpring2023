using CourseWorkSpring2023.Custom;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseWorkSpring2023.Models.HomeViewModels
{
    public class PostViewModel
    {
        [Required]
        [Display(Name = "Заголовок")]
        public string Header { get; set; }

        [Required]
        [StringLength(240, ErrorMessage = "Ограничение на 240 символов")]
        public string Text { get; set; }

        public int Upvotes { get; set; }

        public int Downvotes { get; set; }

        public DateTime Posted { get; set; }

        public IEnumerable<PostsTags> Tags { get; set; }

        public CustomUser User { get; set; }

    }
}
