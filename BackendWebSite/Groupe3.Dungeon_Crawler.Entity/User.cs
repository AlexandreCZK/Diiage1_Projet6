using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Groupe3.Dungeon_Crawler.Entity
{
    public class User : Entity
    {
        /// <summary>
        /// Mail of user
        /// </summary>
        public string Mail { get; set; }

        /// <summary>
        /// First name of user
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of user
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Birth date of user
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// HashedPassword
        /// </summary>
        public byte[] PasswordHash { get; set; }

        /// <summary>
        /// Salt for the hashed password
        /// </summary>
        public byte[] PasswordSalt { get; set; }

        /// <summary>
        /// Connected to the game ?
        /// </summary>
        public bool IsConnected { get; set; }

        /// <summary>
        /// Characters of the user
        /// </summary>
        public List<Character> Characters { get; set; }

        /// <summary>
        /// Friends of the user
        /// </summary>
        [NotMapped]
        public List<UserFriend> Friends { get; set; }
    }
}
