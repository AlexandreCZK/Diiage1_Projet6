namespace Groupe3.Dungeon_Crawler.Entity.Game
{
    public class DungeonsCrawlerMongoDbSettings : IDungeonsCrawlerMongoDbSettings
    {
        public string CollectionName { get; set; }
        public string DatabaseName { get; set; }

    }

    public interface IDungeonsCrawlerMongoDbSettings
    {
        string CollectionName { get; set; }
        string DatabaseName { get; set; }
    }
}