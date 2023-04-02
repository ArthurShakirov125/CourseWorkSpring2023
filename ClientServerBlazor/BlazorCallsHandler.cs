using CourseWorkSpring2023.DataAccessLayer;
using System.Diagnostics;

namespace CourseWorkSpring2023.ClientServerBlazor
{
    public class BlazorCallsHandler
    {

        public BlazorCallsHandler(FollowersRepository followersRepository)
        {
            _followersRepository = followersRepository;
        }

        public FollowersRepository _followersRepository;

        public void Follow(string followerId, string userToFollow)
        {
            _followersRepository.FollowUser(followerId, userToFollow);
        }

        public void UnFollowUser(string followerId, string userToUnFollow)
        {
            _followersRepository.UnFollowUser(followerId, userToUnFollow);
        }
    }
}
