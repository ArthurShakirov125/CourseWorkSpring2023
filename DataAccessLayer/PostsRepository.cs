using CourseWorkSpring2023.Abstract;
using CourseWorkSpring2023.Entities;
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
            db = dbContext;
        }
        private readonly ApplicationDbContext db;

        public void Create(Post post)
        {
            db.Posts.Add(post);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var postRatings = db.Rates.Where(r => r.Content.Id == id);
            var comments = db.Comments.Where(c => c.Post.Id == id);

            var commentsRatings = new List<UserContentRates>();

            foreach (var comment in comments)
            {
                commentsRatings.AddRange(db.Rates.Where(r => r.Content.Id == comment.Id));
            }

            db.Rates.RemoveRange(commentsRatings);
            db.Rates.RemoveRange(postRatings);

            db.Comments.RemoveRange(comments);

            db.Posts.Remove(Read(id));

            db.SaveChanges();
        }

        public IEnumerable<Post> GetList() => db.Posts.Include(p => p.User).Include(p => p.Comments).Include(p => p.Tags);

        public IEnumerable<Post> GetUsersPosts(CustomUser user)
        {
            return db.Posts.Where(p => p.User.Id == user.Id).Include(p => p.User).Include(p => p.Comments).Include(p => p.Tags);
        }

        public IEnumerable<Post> GetUsersPosts(string userId)
        {
            return db.Posts.Where(p => p.User.Id == userId).Include(p => p.User).Include(p => p.Comments).Include(p => p.Tags);
        }

        public IEnumerable<Comment> GetPostsComments(int postId)
        {
            return db.Comments.Where(c => c.Post.Id == postId).Include(c => c.User);
        }

        public Post Read(int id) => db.Posts.Include(p => p.User).Include(p => p.Comments).Include(p => p.Tags).Where(p => p.Id == id).First();

        public void Update(Post model)
        {
            var post = Read(model.Id);

            post.Text = model.Text;
            post.Downvotes = model.Downvotes;
            post.Upvotes = model.Upvotes;
            post.Tags = model.Tags;

            db.SaveChanges();
        }

        public int AddComment(string userName, int postId, string commentText)
        {
            CustomUser user = db.Users.First(u => u.UserName == userName);

            var postToUpdate = Read(postId);

            var comment = new Comment()
            {
                Post = postToUpdate,
                Text = commentText,
                User = user,
                Uploaded = System.DateTime.Now,
            };

            db.Comments.Add(comment);
            postToUpdate.Comments.Add(comment);

            db.SaveChanges();

            return comment.Id;
        }

        public IEnumerable<Post> GetFollowedPosts(CustomUser user)
        {
            var users = db.Followers.Where(f => f.FollowerId == user.Id).Select(f => f.FollowedId);

            List<Post> posts = new List<Post>();

            foreach(var u in users)
            {
                posts.AddRange(GetUsersPosts(u));
            }

            return posts;
        }
    }


    
}
