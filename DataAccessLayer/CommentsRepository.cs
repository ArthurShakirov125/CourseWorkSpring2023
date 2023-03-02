using CourseWorkSpring2023.Custom;
using CourseWorkSpring2023.Data;
using System.Collections.Generic;
using System.Linq;

namespace CourseWorkSpring2023.DataAccessLayer
{
    public class CommentsRepository
    {
        private ApplicationDbContext db;
        public CommentsRepository(ApplicationDbContext db) { this.db = db; }

        public void Create(Comment model)
        {
            
        }

        public void Delete(int id)
        {
            var com = Read(id);
            db.Comments.Remove(com);
            db.SaveChanges();
        }

        public IEnumerable<Comment> GetList(CustomUser user)
        {
           return db.Comments.Where(c => c.Commentator.Id == user.Id);
        }

        public Comment Read(int id) => db.Comments.Find(id);

        public void Update(Comment model)
        {
            var com = Read(model.Id);
            com.Text = model.Text;
            db.SaveChanges();
        }

        public void Upvote(int commentId, CustomUser user)
        {
            Comment comment = db.Comments.Find(commentId);
            comment.Upvotes++;
            db.UsersCommentsRates.Add(new UsersCommentsRates() { CustomUser = user, Comment = comment, isUpvote = true });
            db.SaveChanges();
        }
        public void RemoveUpvote(int commentId, CustomUser user)
        {
            var entry = db.UsersCommentsRates.First(p => p.CustomUser.Id == user.Id && p.Comment.Id == commentId);
            Comment comment = db.Comments.Find(commentId);
            comment.Upvotes--;
            db.UsersCommentsRates.Remove(entry);
            db.SaveChanges();
        }

        public void Downvote(int commentId, CustomUser user)
        {
            Comment comment = db.Comments.Find(commentId);
            comment.Downvotes++;
            db.UsersCommentsRates.Add(new UsersCommentsRates() { CustomUser = user, Comment = comment, isUpvote = false });
            db.SaveChanges();
        }

        public void RemoveDownvote(int commentId, CustomUser user)
        {
            var entry = db.UsersCommentsRates.First(p => p.CustomUser.Id == user.Id && p.Comment.Id == commentId);
            Comment comment = db.Comments.Find(commentId);
            comment.Downvotes--;
            db.UsersCommentsRates.Remove(entry);
            db.SaveChanges();
        }

        public void DownvoteAndRemoveUpvote(int commentId, CustomUser user)
        {
            var entry = db.UsersCommentsRates.First(p => p.CustomUser.Id == user.Id && p.Comment.Id == commentId);
            Comment comment = db.Comments.Find(commentId);

            entry.isUpvote = false;

            comment.Downvotes++;
            comment.Upvotes--;

            db.SaveChanges();
        }

        public void UpvoteAndRemoveDownvote(int commentId, CustomUser user)
        {
            var entry = db.UsersCommentsRates.First(p => p.CustomUser.Id == user.Id && p.Comment.Id == commentId);
            Comment comment = db.Comments.Find(commentId);

            entry.isUpvote = true;

            comment.Downvotes--;
            comment.Upvotes++;

            db.SaveChanges();
        }
    }
}
