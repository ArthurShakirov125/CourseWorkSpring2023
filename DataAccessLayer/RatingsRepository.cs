using CourseWorkSpring2023.Custom;
using CourseWorkSpring2023.Data;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Collections.Generic;
using System.Linq;

namespace CourseWorkSpring2023.DataAccessLayer
{
    public class RatingsRepository
    {
        private readonly ApplicationDbContext _context;
        public RatingsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Post> UsersRates(CustomUser user)
        {
            return _context.UsersPostsRates.Where(r => r.CustomUser.Id == user.Id).Select(r => r.Post);
        }

        public void Upload(Post post, CustomUser user)
        {
            Post liked = _context.Posts.Find(post);
            liked.Upvotes++;

            _context.UsersPostsRates.Add(new UsersPostsRates() { CustomUser = user, Post = liked});

            _context.SaveChanges();

        }

        public void Download(Post post, CustomUser user)
        {
            Post liked = _context.Posts.Find(post);
            liked.Downvotes++;

            _context.UsersPostsRates.Add(new UsersPostsRates() { CustomUser = user, Post = liked });

            _context.SaveChanges();
        }
    }
}
