using CourseWorkSpring2023.DataAccessLayer;
using System.Diagnostics;

namespace CourseWorkSpring2023.ClientServerBlazor
{
    public class BlazorCallsHandler
    {

        public BlazorCallsHandler(FollowersRepository followersRepository, 
            PostsRepository postsManager, ContentRepository contentManager, CommentsRepository commentsManager)
        {
            _followersRepository = followersRepository;
            this.postsManager = postsManager;
            this.contentManager = contentManager;
            this.commentsManager = commentsManager;
        }

        private FollowersRepository _followersRepository;
        private PostsRepository postsManager;
        private ContentRepository contentManager;
        private CommentsRepository commentsManager;

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
    }
}
