using Groupe3.Dungeon_Crawler.Entity.Game;
using System;
using System.Collections.Generic;

namespace Groupe3.Dungeon_Crawler.Entity.Helper
{
    public static class HelperGame
    {
        public static void CreateRoom(Game.Game game)
        {
            var random = new Random();
            game.Rooms = new List<Room>();
            var nbrRoom = random.Next(15, 20);
            var doorPossible = new string[] { "left", "right", "front" };
            var monstrePossible = new string[] { "orc", "necromancian", "gobelin" };
            var treasurePossible = new string[] { "xp", "health" };
            for (int i = 0; i < nbrRoom; i++)
            {
                #region DoorsGenerations
                var doors = new List<string>();
                for (int j = 0; j < doorPossible.Length; j++)
                {
                    var isPresent = random.Next(0, 2);
                    if (isPresent == 0)
                    {
                        doors.Add(doorPossible[j]);
                    }
                }
                if (doors.Count == 0)
                {
                    doors.Add("front");
                }
                #endregion
                #region MonsterGenerations
                var monsters = new List<Monster>();
                for (int j = 0; j < monstrePossible.Length; j++)
                {
                    var randomMonstre = random.Next(0, 3);
                    var lvl = random.Next(game.Character.Level + 1, game.Character.Level + 4);
                    switch (monstrePossible[randomMonstre])
                    {
                        case "orc":
                            monsters.Add(HelperMonster.CreateOrc(lvl));
                            break;
                        case "necromancian":
                            monsters.Add(HelperMonster.CreateNecromancian(lvl));
                            break;
                        case "gobelin":
                            monsters.Add(HelperMonster.CreateGobelin(lvl));
                            break;
                    }
                }
                #endregion
                #region TreasureGeneration
                var treasure = new List<Item>();
                for (int j = 0; j < treasurePossible.Length; j++)
                {
                    var isPresent = random.Next(0, 2);
                    if (isPresent == 0)
                    {
                        switch (treasurePossible[j])
                        {
                            case "xp":
                                treasure.Add(new Item { Libelle = "xp", Value = random.Next(100, 500) });
                                break;
                            case "health":
                                treasure.Add(new Item { Libelle = "health", Value = random.Next(50, 250) });
                                break;
                        }
                    }
                }
                #endregion
                var room = new Room
                {
                    RoomId = game.Rooms.Count + 1,
                    Doors = doors,
                    Monsters = monsters,
                    Treasure = treasure,
                    IsBoos = false,
                };
                game.Rooms.Add(room);
            }
            CreateRoomBoss(game);
        }
        private static void CreateRoomBoss(Game.Game game)
        {
            var random = new Random();
            var monstrePossible = new string[] { "wizzard", "warrior" };
            var treasurePossible = new string[] { "xp", "health" };
            #region MonsterGenerations
            var monster = new List<Monster>();
            var randomMonstre = random.Next(0, 2);
            var lvl = game.Character.Level + 5;
            switch (monstrePossible[randomMonstre])
            {
                case "wizzard":
                    monster.Add(HelperMonster.CreateWizzardBoss(lvl));
                    break;
                case "warrior":
                    monster.Add(HelperMonster.CreateWarriorBoss(lvl));
                    break;
            }
            #endregion
            #region TreasureGeneration
            var treasure = new List<Item>();
            for (int j = 0; j < treasurePossible.Length; j++)
            {
                var isPresent = random.Next(0, 2);
                if (isPresent == 0)
                {
                    switch (treasurePossible[j])
                    {
                        case "xp":
                            treasure.Add(new Item { Libelle = "xp", Value = random.Next(100, 500) });
                            break;
                        case "health":
                            treasure.Add(new Item { Libelle = "health", Value = random.Next(50, 250) });
                            break;
                    }
                }
            }
            #endregion
            var room = new Room
            {
                RoomId = game.Rooms.Count + 1,
                Doors = new List<string> { "Exit" },
                Monsters = monster,
                Treasure = treasure,
                IsBoos = true,
            };
            game.Rooms.Add(room);
        }
    }
}
