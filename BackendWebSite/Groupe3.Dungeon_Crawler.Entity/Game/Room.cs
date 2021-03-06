using System.Collections.Generic;

namespace Groupe3.Dungeon_Crawler.Entity.Game
{
    public class Room
    {
        public int RoomId { get; set; }
        public List<string> Doors { get; set; }
        public List<Item> Treasure { get; set; }
        public List<Monster> Monsters { get; set; }
        public bool IsBoos { get; set; }
    }
}