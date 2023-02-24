namespace CourseWorkSpring2023.Custom
{
    public class Comment
    {
        public int Id { get; set; } 
        public string Text { get; set; }
        public Post Post { get; set; }
        public CustomUser Commentator { get; set; }
    }
}
