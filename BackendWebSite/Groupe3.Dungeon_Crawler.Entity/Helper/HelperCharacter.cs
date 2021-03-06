using System.Collections.Generic;

namespace Groupe3.Dungeon_Crawler.Entity.Helper
{
    public static class HelperCharacter
    {
        public static Character CreateWarrior(string name, User user)
        {
            return new Character
            {
                ClassName = "Warrior",
                BasePv = 60,
                Strenght = 10,
                Stamina = 10,
                Intelligence = 3,
                Agility = 5,
                Speed = 5,
                StrenghtPerLevel = 3,
                StaminaPerLevel = 3,
                IntelligencePerLevel = 1,
                AgilityPerLevel = 1,
                SpeedPerLevel = 2,
                Experience = 0,
                Level = 1,
                Name = name,
                User = user,
                UserId = user.Id,

                Skills = new List<Skill>
                {
                    new Skill{ Name="Shield Strike", NbTurnToPrepare=0, CoefDamages=1.5, LevelToUnlock=1, Target="single", LocationSkills=1, IsEnable=true },
                    new Skill{ Name="Thunder Clap", NbTurnToPrepare=1, CoefDamages=1.4, LevelToUnlock=10, Target="multi", LocationSkills=2, IsEnable=false },
                    new Skill{ Name="Revenge", NbTurnToPrepare=2, CoefDamages=2, LevelToUnlock=20, Target="single", LocationSkills=3, IsEnable=false },
                    new Skill{ Name="Devastate", NbTurnToPrepare=0, CoefDamages=1.8, LevelToUnlock=30, Target="single", LocationSkills=1, IsEnable=false },
                    new Skill{ Name="Multiple Shoots", NbTurnToPrepare=1, CoefDamages=1.6, LevelToUnlock=40, Target="multi", LocationSkills=2, IsEnable=false },
                    new Skill{ Name="Slay", NbTurnToPrepare=2, CoefDamages=2.4, LevelToUnlock=50, Target="multi", LocationSkills=3, IsEnable=false }
                }
            };
        }

        public static Character CreateShaman(string name, User user)
        {
            return new Character
            {
                ClassName = "Shaman",
                BasePv = 50,
                Strenght = 7,
                Stamina = 8,
                Intelligence = 5,
                Agility = 10,
                Speed = 5,
                StrenghtPerLevel = 1,
                StaminaPerLevel = 2,
                IntelligencePerLevel = 3,
                AgilityPerLevel = 2,
                SpeedPerLevel = 2,
                Experience = 0,
                Level = 1,
                Name = name,
                User = user,
                UserId = user.Id,

                Skills = new List<Skill>
                {
                    new Skill{ Name="Flame Shock", NbTurnToPrepare=0, CoefDamages=1.4, LevelToUnlock=1, Target="single", LocationSkills=1, IsEnable=true },
                    new Skill{ Name="Lightning", NbTurnToPrepare=1, CoefDamages=1.3, LevelToUnlock=10, Target="single", LocationSkills=2, IsEnable=false },
                    new Skill{ Name="Lightning chain", NbTurnToPrepare=2, CoefDamages=2.1, LevelToUnlock=20, Target="multi", LocationSkills=3, IsEnable=false },
                    new Skill{ Name="Ancestral spirit", NbTurnToPrepare=0, CoefDamages=4, LevelToUnlock=30, LocationSkills=1, IsEnable=false },
                    new Skill{ Name="Earthquake", NbTurnToPrepare=1, CoefDamages=1.5, LevelToUnlock=40, Target="multi", LocationSkills=2, IsEnable=false },
                    new Skill{ Name="Lava explosion", NbTurnToPrepare=2, CoefDamages=2.4, LevelToUnlock=50, Target="single", LocationSkills=3, IsEnable=false }
                }
            };
        }

        public static Character CreateWizard(string name, User user)
        {
            return new Character
            {
                ClassName = "Wizard",
                BasePv = 45,
                Strenght = 7,
                Stamina = 6,
                Intelligence = 12,
                Agility = 5,
                Speed = 5,
                StrenghtPerLevel = 1,
                StaminaPerLevel = 2,
                IntelligencePerLevel = 3,
                AgilityPerLevel = 1,
                SpeedPerLevel = 2,
                Experience = 0,
                Level = 1,
                Name = name,
                User = user,
                UserId = user.Id,

                Skills = new List<Skill>
                {
                     new Skill{ Name="Fire bold", NbTurnToPrepare=0, CoefDamages=1.3, LevelToUnlock=1, Target="single", LocationSkills=1, IsEnable=true },
                    new Skill{ Name="Frosted bold", NbTurnToPrepare=1, CoefDamages=1.5, LevelToUnlock=10, Target="single", LocationSkills=2, IsEnable=false },
                    new Skill{ Name="Arcane explosion", NbTurnToPrepare=2, CoefDamages=2.1, LevelToUnlock=20, Target="multi", LocationSkills=3, IsEnable=false },
                    new Skill{ Name="Frosted nova", NbTurnToPrepare=0, CoefDamages=1.2, LevelToUnlock=30, Target="multi", LocationSkills=1, IsEnable=false },
                    new Skill{ Name="Arcane projectiles", NbTurnToPrepare=1, CoefDamages=2.1, LevelToUnlock=40, Target="single", LocationSkills=2, IsEnable=false },
                    new Skill{ Name="Fire explosion", NbTurnToPrepare=2, CoefDamages=2.6, LevelToUnlock=50, Target="multi", LocationSkills=3, IsEnable=false }
                }
            };
        }
    }
}
