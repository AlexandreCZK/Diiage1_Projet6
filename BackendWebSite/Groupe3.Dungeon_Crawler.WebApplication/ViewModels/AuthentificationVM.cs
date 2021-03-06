using System;

namespace Groupe3.Dungeon_Crawler.WebApplication.ViewModels
{
    public class AuthentificationVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate{ get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
    }
}
