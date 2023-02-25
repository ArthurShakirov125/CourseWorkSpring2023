using CourseWorkSpring2023.Custom;
using CourseWorkSpring2023.Data;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
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

        public IEnumerable<Post> UsersUpvotes(CustomUser user)
        {
            return _context.UsersPostsRates.Where(r => r.CustomUser.Id == user.Id && r.isUpvote).Select(r => r.Post);
        }

        public IEnumerable<Post> UsersDownvotes(CustomUser user)
        {
            return _context.UsersPostsRates.Where(r => r.CustomUser.Id == user.Id && !r.isUpvote).Select(r => r.Post);
        }

        public void Upvote(int postId, CustomUser user)
        {
            Post post = _context.Posts.Find(postId);
            post.Upvotes++;
            _context.UsersPostsRates.Add(new UsersPostsRates() { CustomUser = user, Post = post, isUpvote = true });
            _context.SaveChanges();
        }
        public void RemoveUpvote(int postId, CustomUser user)
        {
            var entry = _context.UsersPostsRates.First(p => p.CustomUser.Id == user.Id && p.Post.Id == postId);
            Post post = _context.Posts.Find(postId);
            post.Upvotes--;
            _context.UsersPostsRates.Remove(entry);
            _context.SaveChanges();
        }

        public void Downvote(int postId, CustomUser user)
        {
            Post post = _context.Posts.Find(postId);
            post.Downvotes++;
            _context.UsersPostsRates.Add(new UsersPostsRates() { CustomUser = user, Post = post, isUpvote = false });
            _context.SaveChanges();
        }

        public void RemoveDownvote(int postId, CustomUser user)
        {
            var entry = _context.UsersPostsRates.First(p => p.CustomUser.Id == user.Id && p.Post.Id == postId);
            Post post = _context.Posts.Find(postId);
            post.Downvotes--;
            _context.UsersPostsRates.Remove(entry);
            _context.SaveChanges();
        }
    }
}
