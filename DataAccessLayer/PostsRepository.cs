using CourseWorkSpring2023.Abstract;
using CourseWorkSpring2023.Custom;
using CourseWorkSpring2023.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CourseWorkSpring2023.DataAccessLayer
{
    public class PostsRepository : ICrud<Post>
    {

        public PostsRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        private readonly ApplicationDbContext _context;

        public void Create(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Posts.Remove(Read(id));
            _context.SaveChanges();
        }

        public IEnumerable<Post> GetList() => _context.Posts.Include(p => p.User);


        public Post Read(int id) => _context.Posts.Find(id);

        public void Update(Post model)
        {
            var post = Read(model.Id);

            post.Text = model.Text;
            post.Downvotes = model.Downvotes;
            post.Upvotes = model.Upvotes;
            post.Tags = model.Tags;

            _context.SaveChanges();
        } 
    }
}
