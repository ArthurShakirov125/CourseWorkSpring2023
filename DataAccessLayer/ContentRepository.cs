using CourseWorkSpring2023.Abstract;
using CourseWorkSpring2023.Data;

namespace CourseWorkSpring2023.DataAccessLayer
{
    public class ContentRepository
    {
        private readonly ApplicationDbContext db;

        public ContentRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public UploadableContent FindContent(int contentId)
        {
            UploadableContent content = db.Posts.Find(contentId);
            if (content == null)
            {
                content = db.Comments.Find(contentId);
            }
            return content;
        }

        public void Hide(int Id)
        {
            var postToUpdate = FindContent(Id);
            postToUpdate.IsHidden = true;
            db.SaveChanges();
        }

        public void UnHide(int Id)
        {
            var postToUpdate = FindContent(Id);
            postToUpdate.IsHidden = false;
            db.SaveChanges();
        }



    }
}
