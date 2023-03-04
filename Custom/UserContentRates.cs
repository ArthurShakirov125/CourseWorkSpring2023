using CourseWorkSpring2023.Abstract;

namespace CourseWorkSpring2023.Custom
{
    public class UserContentRates
    {
        public int Id { get; set; }
        public CustomUser CustomUser { get; set; }
        public UploadableContent Content { get; set; }
        public bool isUpvote { get; set; }
    }
}
