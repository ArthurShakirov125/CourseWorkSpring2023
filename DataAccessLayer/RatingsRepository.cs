using CourseWorkSpring2023.Abstract;
using CourseWorkSpring2023.Entities;
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
        private readonly ApplicationDbContext db;
        public RatingsRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public IEnumerable<UploadableContent> UsersRates(CustomUser user)
        {
            return db.Rates.Where(r => r.CustomUser.Id == user.Id).Select(r => r.Content);
        }

        public IEnumerable<UploadableContent> UsersUpvotes(CustomUser user)
        {
            return db.Rates.Where(r => r.CustomUser.Id == user.Id && r.isUpvote).Select(r => r.Content);
        }

        public IEnumerable<UploadableContent> UsersDownvotes(CustomUser user)
        {
            return db.Rates.Where(r => r.CustomUser.Id == user.Id && !r.isUpvote).Select(r => r.Content);
        }

        public UploadableContent FindContent(int contentId)
        {
            UploadableContent content = db.Posts.Find(contentId);
            if(content == null)
            {
                content = db.Comments.Find(contentId);
            }
            return content;
        }

        public void Upvote(int contentId, string userId)
        {
            var user = db.Users.Find(userId);
            UploadableContent content = FindContent(contentId);
            content.Upvotes++;
            db.Rates.Add(new UserContentRates() { CustomUser = user, Content = content, isUpvote = true });
            db.SaveChanges();
        }
        public void RemoveUpvote(int contentId, string userId)
        {

            var entry = db.Rates.First(p => p.CustomUser.Id == userId && p.Content.Id == contentId);
            UploadableContent content = FindContent(contentId);
            content.Upvotes--;
            db.Rates.Remove(entry);
            db.SaveChanges();
        }

        public void Downvote(int contentId, string userId)
        {
            var user = db.Users.Find(userId);
            UploadableContent content = FindContent(contentId);
            content.Downvotes++;
            db.Rates.Add(new UserContentRates() { CustomUser = user, Content = content, isUpvote = false });
            db.SaveChanges();
        }

        public void RemoveDownvote(int contentId, string userId)
        {
            var entry = db.Rates.First(p => p.CustomUser.Id == userId && p.Content.Id == contentId);
            UploadableContent content = FindContent(contentId);
            content.Downvotes--;
            db.Rates.Remove(entry);
            db.SaveChanges();
        }

        public void DownvoteAndRemoveUpvote(int contentId, string userId)
        {
            var entry = db.Rates.First(p => p.CustomUser.Id == userId && p.Content.Id == contentId);
            UploadableContent content = FindContent(contentId);

            entry.isUpvote = false;

            content.Downvotes++;
            content.Upvotes--;

            db.SaveChanges();
        }

        public void UpvoteAndRemoveDownvote(int contentId, string userId)
        {
            var entry = db.Rates.First(p => p.CustomUser.Id == userId && p.Content.Id == contentId);
            UploadableContent content = FindContent(contentId);

            entry.isUpvote = true;

            content.Downvotes--;
            content.Upvotes++;

            db.SaveChanges();
        }
    }
}
