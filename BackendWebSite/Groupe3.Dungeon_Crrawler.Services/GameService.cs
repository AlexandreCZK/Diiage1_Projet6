using System.Linq;
using Groupe3.Dungeon_Crawler.Entity;
using Groupe3.Dungeon_Crawler.Entity.Game;
using Groupe3.Dungeon_Crawler.Entity.Helper;
using MongoDB.Driver;
using System;

namespace Groupe3.Dungeon_Crrawler.Services
{
    public class GameService
    {
        private IMongoCollection<Game> _games;

        public GameService(IDungeonsCrawlerMongoDbSettings settings)
        {
            var client = new MongoClient(Environment.GetEnvironmentVariable("CONNEXION_STRING_MONGO"));
            //var client = new MongoClient("mongodb://localhost:27019");
            var database = client.GetDatabase(settings.DatabaseName);
            
            _games = database.GetCollection<Game>(settings.CollectionName);
        }

        public Game Get(string id)
        {
            return _games.Find(game => game.GameId == id).FirstOrDefault();
        }
        public void Update(Game game){
            _games.ReplaceOne(g => g.GameId == game.GameId, game);
        }
        public Game Create(Game game)
        {
            HelperGame.CreateRoom(game);
            game.Character.CurrentLife = game.Character.BasePv + (game.Character.Stamina + game.Character.StaminaPerLevel * (game.Character.Level - 1)) * 6;
            game.Character.MaxLife = game.Character.CurrentLife;
            game.Rooms.ForEach(r => r.Monsters.ForEach(m => m.CurrentLife = m.BasePv + (m.Stamina + m.StaminaPerLevel * (m.Level - 1)) * 6));
            game.Rooms.ForEach(r => r.Monsters.ForEach(m => m.MaxLife = m.CurrentLife));
            _games.InsertOne(game);
            return game;
        }

        public Room GetRoom(string gameId, int nbrRoom)
        {
            var game = _games.Find(game => game.GameId == gameId).FirstOrDefault();
            return game.Rooms[nbrRoom];
        }

        public void UseSkill(string gameId, int nbRoom, int launcherId, int targetId, int numberOfSkill){
            var game = this.Get(gameId);
            var room = game.Rooms[nbRoom];
            Entity launcher = room.Monsters.Any(m => m.Id == launcherId) ? room.Monsters.First(m => m.Id == launcherId) : game.Character;
            Entity target = room.Monsters.Any(m => m.Id == targetId) ? room.Monsters.First(m => m.Id == targetId) : game.Character;
            var type = launcher.GetType().FullName;
            if (type.Contains("Monster"))//TYPE OF LAUCHER
            {
                Monster launcherM = (Monster)launcher;
                Character targetC = (Character)target;

                var dmg = launcherM.UseSkill(numberOfSkill);
                targetC.CurrentLife = targetC.CurrentLife - dmg;
            }
            else{
                Character launcherC = (Character)launcher;
                Monster targetM = (Monster)target;

                var dmg = launcherC.UseSkill(numberOfSkill);
                targetM.CurrentLife = targetM.CurrentLife - dmg;
            }
            this.Update(game);
        }
    }
}
