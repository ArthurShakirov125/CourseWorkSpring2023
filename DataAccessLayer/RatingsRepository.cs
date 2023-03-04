using CourseWorkSpring2023.Abstract;
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

        public IEnumerable<UploadableContent> UsersRates(CustomUser user)
        {
            return _context.Rates.Where(r => r.CustomUser.Id == user.Id).Select(r => r.Content);
        }

        public IEnumerable<UploadableContent> UsersUpvotes(CustomUser user)
        {
            return _context.Rates.Where(r => r.CustomUser.Id == user.Id && r.isUpvote).Select(r => r.Content);
        }

        public IEnumerable<UploadableContent> UsersDownvotes(CustomUser user)
        {
            return _context.Rates.Where(r => r.CustomUser.Id == user.Id && !r.isUpvote).Select(r => r.Content);
        }

        public UploadableContent FindContent(int contentId)
        {
            UploadableContent content = _context.Posts.Find(contentId);
            if(content == null)
            {
                content = _context.Comments.Find(contentId);
            }
            return content;
        }

        public void Upvote(int contentId, CustomUser user)
        {
            UploadableContent content = FindContent(contentId);
            content.Upvotes++;
            _context.Rates.Add(new UserContentRates() { CustomUser = user, Content = content, isUpvote = true });
            _context.SaveChanges();
        }
        public void RemoveUpvote(int contentId, CustomUser user)
        {
            var entry = _context.Rates.First(p => p.CustomUser.Id == user.Id && p.Content.Id == contentId);
            UploadableContent content = FindContent(contentId);
            content.Upvotes--;
            _context.Rates.Remove(entry);
            _context.SaveChanges();
        }

        public void Downvote(int contentId, CustomUser user)
        {
            UploadableContent content = FindContent(contentId);
            content.Downvotes++;
            _context.Rates.Add(new UserContentRates() { CustomUser = user, Content = content, isUpvote = false });
            _context.SaveChanges();
        }

        public void RemoveDownvote(int contentId, CustomUser user)
        {
            var entry = _context.Rates.First(p => p.CustomUser.Id == user.Id && p.Content.Id == contentId);
            UploadableContent content = FindContent(contentId);
            content.Downvotes--;
            _context.Rates.Remove(entry);
            _context.SaveChanges();
        }

        public void DownvoteAndRemoveUpvote(int contentId, CustomUser user)
        {
            var entry = _context.Rates.First(p => p.CustomUser.Id == user.Id && p.Content.Id == contentId);
            UploadableContent content = FindContent(contentId);

            entry.isUpvote = false;

            content.Downvotes++;
            content.Upvotes--;

            _context.SaveChanges();
        }

        public void UpvoteAndRemoveDownvote(int contentId, CustomUser user)
        {
            var entry = _context.Rates.First(p => p.CustomUser.Id == user.Id && p.Content.Id == contentId);
            UploadableContent content = FindContent(contentId);

            entry.isUpvote = true;

            content.Downvotes--;
            content.Upvotes++;

            _context.SaveChanges();
        }
    }
}
