namespace Groupe3.Dungeon_Crawler.Entity
{
    public class UserFriend : Entity
    {
        /// <summary>
        /// User who have the friend
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// The friend
        /// </summary>
        public User Friend { get; set; }

        /// <summary>
        /// UserId who have the friend
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// The FriendId
        /// </summary>
        public long FriendId { get; set; }
    }
}