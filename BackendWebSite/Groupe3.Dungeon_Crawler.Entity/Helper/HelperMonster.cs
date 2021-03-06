using Groupe3.Dungeon_Crawler.Entity.Game;
using System;
using System.Collections.Generic;

namespace Groupe3.Dungeon_Crawler.Entity.Helper
{
    //TODO RANDOM ON Skills enable
    public static class HelperMonster
    {
        static int _id = 0;
        public static Monster CreateGobelin(int lvl)
        {
            _id++;
            var monster = new Monster
            {
                Id = _id,
                ClassName = "Gobelin",
                BasePv = 30,
                Strenght = 5,
                Stamina = 5,
                Intelligence = 8,
                Agility = 12,
                Speed = 5,
                StrenghtPerLevel = 1,
                StaminaPerLevel = 1,
                IntelligencePerLevel = 2,
                AgilityPerLevel = 3,
                SpeedPerLevel = 2,
                Level = lvl,
                XpWhenDie = lvl * 100,
                Skills = new List<Skill>
                {
                    new Skill{ Name="Dynamic stick", NbTurnToPrepare=0, CoefDamages=1.2, LevelToUnlock=1, Target="single", LocationSkills=1, IsEnable=false },
                    new Skill{ Name="Hydroglycerine", NbTurnToPrepare=1, CoefDamages=0.5, LevelToUnlock=10, Target="multi", LocationSkills=2, IsEnable=false },
                    new Skill{ Name="Bomba explosive", NbTurnToPrepare=2, CoefDamages=0.9, LevelToUnlock=20, Target="multi", LocationSkills=3, IsEnable=false },
                    new Skill{ Name="Grenade", NbTurnToPrepare=0, CoefDamages=1.1, LevelToUnlock=30, Target="multi", LocationSkills=1, IsEnable=false },
                    new Skill{ Name="Death Ray", NbTurnToPrepare=1, CoefDamages=1.7, LevelToUnlock=40, Target="single", LocationSkills=2, IsEnable=false },
                    new Skill{ Name="Sheep explosive", NbTurnToPrepare=2, CoefDamages=1.5, LevelToUnlock=50, Target="multi", LocationSkills=3, IsEnable=false }
                }
            };
            for (int i = 0; i <( monster.Skills.Count / 2); i++)
            {
                if (monster.Skills[i].LevelToUnlock <= monster.Level && monster.Skills[i + 3].LevelToUnlock <= monster.Level)
                {
                    var random = new Random().Next(0, 2);
                    if (random == 0)
                    {
                        monster.Skills[i].IsEnable = true;
                    }
                    else
                    {
                        monster.Skills[i + 3].IsEnable = true;
                    }
                }
                else if (monster.Skills[i].LevelToUnlock <= monster.Level)
                {
                    monster.Skills[i].IsEnable = true;
                }
            }
            return monster;
        }

        public static Monster CreateNecromancian(int lvl)
        {
            _id++;
            var monster =  new Monster
            {
                Id = _id,
                ClassName = "Necromancian",
                BasePv = 40,
                Strenght = 9,
                Stamina = 6,
                Intelligence = 12,
                Agility = 3,
                Speed = 5,
                StrenghtPerLevel = 2,
                StaminaPerLevel = 2,
                IntelligencePerLevel = 2,
                AgilityPerLevel = 1,
                SpeedPerLevel = 2,
                Level = lvl,
                XpWhenDie = lvl * 100,
                Skills = new List<Skill>
                {
                    new Skill{ Name="Sword Strike", NbTurnToPrepare=0, CoefDamages=0.8, LevelToUnlock=1, Target="single", LocationSkills=1, IsEnable=false },
                    new Skill{ Name="Purulent strike", NbTurnToPrepare=1, CoefDamages=1.2, LevelToUnlock=10, Target="single", LocationSkills=2, IsEnable=false },
                    new Skill{ Name="Soul reaper", NbTurnToPrepare=2, CoefDamages=0.8, LevelToUnlock=20, Target="multi", LocationSkills=3, IsEnable=false },
                    new Skill{ Name="Death grip", NbTurnToPrepare=0, CoefDamages=1.1, LevelToUnlock=30, Target="multi", LocationSkills=1, IsEnable=false },
                    new Skill{ Name="Bone storm", NbTurnToPrepare=1, CoefDamages=1.3, LevelToUnlock=40, Target="multi", LocationSkills=2, IsEnable=false },
                    new Skill{ Name="Blood pact", NbTurnToPrepare=2, CoefDamages=1.5, LevelToUnlock=50, Target="single/heal", LocationSkills=3, IsEnable=false }
                }
            };
            for (int i = 0; i < (monster.Skills.Count / 2); i++)
            {
                if (monster.Skills[i].LevelToUnlock <= monster.Level && monster.Skills[i + 3].LevelToUnlock <= monster.Level)
                {
                    var random = new Random().Next(0, 2);
                    if (random == 0)
                    {
                        monster.Skills[i].IsEnable = true;
                    }
                    else
                    {
                        monster.Skills[i + 3].IsEnable = true;
                    }
                }
                else if (monster.Skills[i].LevelToUnlock <= monster.Level)
                {
                    monster.Skills[i].IsEnable = true;
                }
            }
            return monster;
        }

        public static Monster CreateOrc(int lvl)
        {
            _id++;
            var monster =  new Monster
            {
                Id = _id,
                ClassName = "Orc",
                BasePv = 60,
                Strenght = 10,
                Stamina = 10,
                Intelligence = 1,
                Agility = 9,
                Speed = 5,
                StrenghtPerLevel = 3,
                StaminaPerLevel = 3,
                IntelligencePerLevel = 1,
                AgilityPerLevel = 2,
                SpeedPerLevel = 2,
                Level = lvl,
                XpWhenDie = lvl * 100,
                Skills = new List<Skill>
                {
                    new Skill{ Name="Sword Strike", NbTurnToPrepare=0, CoefDamages=0.7, LevelToUnlock=1, Target="single", LocationSkills=1, IsEnable=false },
                    new Skill{ Name="Notch", NbTurnToPrepare=1, CoefDamages=0.6, LevelToUnlock=10, Target="multi", LocationSkills=2, IsEnable=false },
                    new Skill{ Name="Deadly bite", NbTurnToPrepare=2, CoefDamages=1.6, LevelToUnlock=20, Target="single", LocationSkills=3, IsEnable=false },
                    new Skill{ Name="Abyssal strike", NbTurnToPrepare=0, CoefDamages=1.2, LevelToUnlock=30, Target="single", LocationSkills=1, IsEnable=false },
                    new Skill{ Name="Deadly sweep", NbTurnToPrepare=1, CoefDamages=1.5, LevelToUnlock=40, Target="multi", LocationSkills=2, IsEnable=false },
                    new Skill{ Name="Sword throwing", NbTurnToPrepare=2, CoefDamages=2.5, LevelToUnlock=50, Target="multi", LocationSkills=3, IsEnable=false }
                }
            };
            for (int i = 0; i < (monster.Skills.Count / 2); i++)
            {
                if (monster.Skills[i].LevelToUnlock <= monster.Level && monster.Skills[i + 3].LevelToUnlock <= monster.Level)
                {
                    var random = new Random().Next(0, 2);
                    if (random == 0)
                    {
                        monster.Skills[i].IsEnable = true;
                    }
                    else
                    {
                        monster.Skills[i + 3].IsEnable = true;
                    }
                }
                else if (monster.Skills[i].LevelToUnlock <= monster.Level)
                {
                    monster.Skills[i].IsEnable = true;
                }
            }
            return monster;
        }

        public static Monster CreateWizzardBoss(int lvl)
        {
            _id++;
            var monster = new Monster
            {
                Id = _id,
                ClassName = "WizzardBoss",
                BasePv = 70,
                Strenght = 10,
                Stamina = 12,
                Intelligence = 12,
                Agility = 6,
                Speed = 5,
                StrenghtPerLevel = 3,
                StaminaPerLevel = 4,
                IntelligencePerLevel = 5,
                AgilityPerLevel = 1,
                SpeedPerLevel = 2,
                Level = lvl,
                XpWhenDie = lvl * 1000,
                Skills = new List<Skill>
                {
                    new Skill{ Name="Fire Ball", NbTurnToPrepare=0, CoefDamages=0.7, LevelToUnlock=1, Target="single", LocationSkills=1, IsEnable=false },
                    new Skill{ Name="Flamestrike", NbTurnToPrepare=1, CoefDamages=0.6, LevelToUnlock=10, Target="multi", LocationSkills=2, IsEnable=false },
                    new Skill{ Name="Arcane disruption", NbTurnToPrepare=2, CoefDamages=1.6, LevelToUnlock=20, Target="multi", LocationSkills=3, IsEnable=false },
                    new Skill{ Name="Pyroblast", NbTurnToPrepare=0, CoefDamages=1.2, LevelToUnlock=30, Target="single", LocationSkills=1, IsEnable=false },
                    new Skill{ Name="Gravity Lapse", NbTurnToPrepare=1, CoefDamages=1.5, LevelToUnlock=40, Target="multi", LocationSkills=2, IsEnable=false },
                    new Skill{ Name="Nether Beam", NbTurnToPrepare=2, CoefDamages=2.5, LevelToUnlock=50, Target="multi", LocationSkills=3, IsEnable=false }
                }
            };
            for (int i = 0; i < (monster.Skills.Count / 2); i++)
            {
                if (monster.Skills[i].LevelToUnlock <= monster.Level && monster.Skills[i + 3].LevelToUnlock <= monster.Level)
                {
                    var random = new Random().Next(0, 2);
                    if (random == 0)
                    {
                        monster.Skills[i].IsEnable = true;
                    }
                    else
                    {
                        monster.Skills[i + 3].IsEnable = true;
                    }
                }
                else if (monster.Skills[i].LevelToUnlock <= monster.Level)
                {
                    monster.Skills[i].IsEnable = true;
                }
            }
            return monster;
        }

        public static Monster CreateWarriorBoss(int lvl)
        {
            _id++;
            var monster = new Monster
            {
                Id = _id,
                ClassName = "WarriorBoss",
                BasePv = 80,
                Strenght = 12,
                Stamina = 12,
                Intelligence = 12,
                Agility = 8,
                Speed = 5,
                StrenghtPerLevel = 4,
                StaminaPerLevel = 5,
                IntelligencePerLevel = 3,
                AgilityPerLevel = 3,
                SpeedPerLevel = 2,
                Level = lvl,
                XpWhenDie = lvl * 1000,
                Skills = new List<Skill>
                {
                    new Skill{ Name="Melee", NbTurnToPrepare=0, CoefDamages=0.7, LevelToUnlock=1, Target="single", LocationSkills=1, IsEnable=false },
                    new Skill{ Name="Hateful strike", NbTurnToPrepare=1, CoefDamages=0.6, LevelToUnlock=10, Target="multi", LocationSkills=2, IsEnable=false },
                    new Skill{ Name="Overwhelm", NbTurnToPrepare=2, CoefDamages=1.3, LevelToUnlock=20, Target="multi", LocationSkills=3, IsEnable=false },
                    new Skill{ Name="Consume", NbTurnToPrepare=0, CoefDamages=1.2, LevelToUnlock=30, Target="single", LocationSkills=1, IsEnable=false },
                    new Skill{ Name="Desolate", NbTurnToPrepare=1, CoefDamages=1.5, LevelToUnlock=40, Target="multi", LocationSkills=2, IsEnable=false },
                    new Skill{ Name="Glottonous", NbTurnToPrepare=2, CoefDamages=2, LevelToUnlock=50, Target="multi", LocationSkills=3, IsEnable=false }
                }
            };
            for (int i = 0; i < (monster.Skills.Count / 2); i++)
            {
                if (monster.Skills[i].LevelToUnlock <= monster.Level && monster.Skills[i + 3].LevelToUnlock <= monster.Level)
                {
                    var random = new Random().Next(0, 2);
                    if (random == 0)
                    {
                        monster.Skills[i].IsEnable = true;
                    }
                    else
                    {
                        monster.Skills[i + 3].IsEnable = true;
                    }
                }
                else if (monster.Skills[i].LevelToUnlock <= monster.Level)
                {
                    monster.Skills[i].IsEnable = true;
                }
            }
            return monster;
        }
    }
}
