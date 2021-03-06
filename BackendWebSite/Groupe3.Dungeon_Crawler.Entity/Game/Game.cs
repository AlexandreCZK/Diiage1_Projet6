using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Groupe3.Dungeon_Crawler.Entity.Game
{
    public class Game
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string GameId { get; set; }
        public Character Character { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
