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
            var rates = db.Rates.Where(r => r.Content.Id == com.Id);

            db.Rates.RemoveRange(rates);
            db.Comments.Remove(com);
            db.SaveChanges();
        }

        public IEnumerable<Comment> GetList(CustomUser user)
        {
           return db.Comments.Where(c => c.User.Id == user.Id);
        }

        public Comment Read(int id) => db.Comments.Find(id);

        public void Update(Comment model)
        {
            var com = Read(model.Id);
            com.Text = model.Text;
            db.SaveChanges();
        }
    }
}
