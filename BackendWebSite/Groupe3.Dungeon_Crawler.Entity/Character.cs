using System.Collections.Generic;

namespace Groupe3.Dungeon_Crawler.Entity
{
    public class Character : Entity
    {
        /// <summary>
        /// Id of the user who possessing the character
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// user who possessing the character
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Name of Character
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name of class of the Character
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// Total XP of the Character
        /// </summary>
        public int Experience { get; set; }

        /// <summary>
        /// Level of the Character
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Current life of the Character
        /// </summary>
        public double CurrentLife { get; set; }

        public double MaxLife { get; set; }

        /// <summary>
        /// Base PV of the Character
        /// </summary>
        public int BasePv { get; set; }

        /// <summary>
        /// Strenght of the Character
        /// </summary>
        public int Strenght { get; set; }

        /// <summary>
        /// Strenght win per level for the Character
        /// </summary>
        public int StrenghtPerLevel { get; set; }

        /// <summary>
        /// Stamina of the Character
        /// </summary>
        public int Stamina { get; set; }

        /// <summary>
        /// Stamina win per level for the Character
        /// </summary>
        public int StaminaPerLevel { get; set; }

        /// <summary>
        /// Intelligence of the Character
        /// </summary>
        public int Intelligence { get; set; }

        /// <summary>
        /// Intelligence win per level for the Character
        /// </summary>
        public int IntelligencePerLevel { get; set; }

        /// <summary>
        /// Agility of the Character
        /// </summary>
        public int Agility { get; set; }

        /// <summary>
        /// Agility win per level for the Character
        /// </summary>
        public int AgilityPerLevel { get; set; }

        /// <summary>
        /// Speed of the Character
        /// </summary>
        public int Speed { get; set; }

        /// <summary>
        /// Speed win per level for the Character
        /// </summary>
        public int SpeedPerLevel { get; set; }

        /// <summary>
        /// All skill of the Character
        /// </summary>
        public List<Skill> Skills { get; set; }

        /// <summary>
        /// List d'item of the character
        /// </summary>
        public List<Item> Items { get; set; }

        public double UseSkill(int nbSkill){
            switch (this.ClassName)
            {
                case "Wizard":
                    if (this.Skills[nbSkill].IsEnable)
                    {
                        return (this.Intelligence + (this.Level - 1) * IntelligencePerLevel) * this.Skills[nbSkill].CoefDamages;
                    }
                    else if (this.Skills[nbSkill + 3].IsEnable)
                    {
                        return (this.Intelligence + (this.Level - 1) * IntelligencePerLevel) * this.Skills[nbSkill + 3].CoefDamages;
                    }
                    else
                    {
                        throw new System.Exception();
                    }
                case "Warrior":
                    if (this.Skills[nbSkill].IsEnable)
                    {
                        return (this.Strenght + (this.Level - 1) * StrenghtPerLevel) * this.Skills[nbSkill].CoefDamages;
                    }
                    else if (this.Skills[nbSkill + 3].IsEnable)
                    {
                        return (this.Strenght + (this.Level - 1) * StrenghtPerLevel) * this.Skills[nbSkill + 3].CoefDamages;
                    }
                    else
                    {
                        throw new System.Exception();
                    }
                case "Shaman":
                    if (this.Skills[nbSkill].IsEnable)
                    {
                        return (this.Intelligence + (this.Level - 1) * Intelligence) * this.Skills[nbSkill].CoefDamages;
                    }
                    else if (this.Skills[nbSkill + 3].IsEnable)
                    {
                        return (this.Intelligence + (this.Level - 1) * Intelligence) * this.Skills[nbSkill + 3].CoefDamages;
                    }
                    else
                    {
                        throw new System.Exception();
                    }
                default:
                    throw new System.Exception();
            }
        }
    }
}
