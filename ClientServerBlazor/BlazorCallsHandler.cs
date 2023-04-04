using CourseWorkSpring2023.DataAccessLayer;
using System.Diagnostics;

namespace CourseWorkSpring2023.ClientServerBlazor
{
    public class BlazorCallsHandler
    {

        public BlazorCallsHandler(FollowersRepository followersRepository,
            PostsRepository postsManager, ContentRepository contentManager, CommentsRepository commentsManager, RatingsRepository ratingsManager)
        {
            _followersRepository = followersRepository;
            this.postsManager = postsManager;
            this.contentManager = contentManager;
            this.commentsManager = commentsManager;
            this.ratingsManager = ratingsManager;
        }

        private FollowersRepository _followersRepository;
        private PostsRepository postsManager;
        private ContentRepository contentManager;
        private CommentsRepository commentsManager;
        private RatingsRepository ratingsManager;

        public void Follow(string followerId, string userToFollow)
        {
            _followersRepository.FollowUser(followerId, userToFollow);
        }

        public void UnFollowUser(string followerId, string userToUnFollow)
        {
            _followersRepository.UnFollowUser(followerId, userToUnFollow);
        }

        public void DeletePost(int postId)
        {
            postsManager.Delete(postId);
        }

        public void DeleteComment(int commentId) 
        {
            commentsManager.Delete(commentId);
        }

        public void Hide(int id)
        {
            contentManager.Hide(id);
        }

        public void Show(int id)
        {
            contentManager.UnHide(id);
        }

        public int CreateComment(string userName, int postId, string text)
        {
            return postsManager.AddComment(userName, postId, text);
        }


        public void Upvote(int contentId, string userId)
        {
            ratingsManager.Upvote(contentId, userId);
        }

        public void Downvote(int contentId, string userId)
        {
            ratingsManager.Downvote(contentId, userId);
        }

        public void RemoveUpvote(int contentId, string userId)
        {
            ratingsManager.RemoveUpvote(contentId, userId);
        }

        public void RemoveDownvote(int contentId, string userId)
        {
            ratingsManager.RemoveDownvote(contentId, userId);
        }

        public void UpvoteRemoveDownvote(int contentId, string userId)
        {
            ratingsManager.UpvoteAndRemoveDownvote(contentId, userId);
        }

        public void DownvoteRemoveUpvote(int contentId, string userId)
        {
            ratingsManager.DownvoteAndRemoveUpvote(contentId, userId);
        }
    }
}
