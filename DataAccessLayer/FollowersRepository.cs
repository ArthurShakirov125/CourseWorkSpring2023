using CourseWorkSpring2023.Data;
using CourseWorkSpring2023.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseWorkSpring2023.DataAccessLayer
{
    public class FollowersRepository
    {
        private readonly ApplicationDbContext db;

        public FollowersRepository(ApplicationDbContext db) 
        {
            this.db = db;
        }

        public void FollowUser(string followerId,string userToFollowId)
        {
            var entry = new Followers()
            {
                FollowerId = followerId,
                FollowedId = userToFollowId,
            };

            db.Followers.Add(entry);
            db.SaveChanges();
        }

        public void UnFollowUser(string followerId, string userToUnFollowId)
        {
            var entry = db.Followers.Where(f => f.FollowerId == followerId && f.FollowedId == userToUnFollowId).First();

            db.Followers.Remove(entry);
            db.SaveChanges();
        }

        public List<string> UserFollowers(string id)
        {
            return db.Followers.Where(pair => pair.FollowedId == id).Select(p => p.FollowerId).ToList();
        }
    }
}
