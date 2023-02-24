using CourseWorkSpring2023.Custom;
using CourseWorkSpring2023.Data;
using Microsoft.EntityFrameworkCore.Internal;
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

        public void Upvote(int postId, CustomUser user)
        {
            if (_context.UsersPostsRates.Any(p => p.CustomUser.Id == user.Id && p.Post.Id == postId))
            {
                var entry = _context.UsersPostsRates.First(p => p.CustomUser.Id == user.Id && p.Post.Id == postId);
                Post liked = _context.Posts.Find(postId);
                liked.Upvotes--;
                _context.UsersPostsRates.Remove(entry);
            }
            else
            {
                Post liked = _context.Posts.Find(postId);
                liked.Upvotes++;
                _context.UsersPostsRates.Add(new UsersPostsRates() { CustomUser = user, Post = liked });
            }

            _context.SaveChanges();
        }

        public void Downvote(int postId, CustomUser user)
        {
            if (_context.UsersPostsRates.Any(p => p.CustomUser.Id == user.Id && p.Post.Id == postId))
            {
                var entry = _context.UsersPostsRates.First(p => p.CustomUser.Id == user.Id && p.Post.Id == postId);
                Post liked = _context.Posts.Find(postId);
                liked.Downvotes--;
                _context.UsersPostsRates.Remove(entry);
            }
            else
            {
                Post liked = _context.Posts.Find(postId);
                liked.Downvotes++;
                _context.UsersPostsRates.Add(new UsersPostsRates() { CustomUser = user, Post = liked });
            }

            _context.SaveChanges();
        }
    }
}
