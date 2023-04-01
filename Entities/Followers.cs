using Microsoft.EntityFrameworkCore;

namespace CourseWorkSpring2023.Entities
{
    public class Followers
    {
        public int Id { get; set; }

        /// <summary>
        /// Тот кто подписался
        /// </summary>
        public string FollowerId { get; set; }

        /// <summary>
        /// Тот на кого подписались
        /// </summary>
        public string FollowedId { get; set; }

    }
}
