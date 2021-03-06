using System.Collections.Generic;

namespace Groupe3.Dungeon_Crawler.Entity.Game
{
    public class Monster : Entity
    {
        public string ClassName { get; set; }
        public int Level { get; set; }
        public int XpWhenDie { get; set; }
        public double CurrentLife { get; set; }
        public double MaxLife { get; set; }
        public int BasePv { get; set; }
        public int Strenght { get; set; }
        public int StrenghtPerLevel { get; set; }
        public int Stamina { get; set; }
        public int StaminaPerLevel { get; set; }
        public int Intelligence { get; set; }
        public int IntelligencePerLevel { get; set; }
        public int Agility { get; set; }
        public int AgilityPerLevel { get; set; }
        public int Speed { get; set; }
        public int SpeedPerLevel { get; set; }
        public List<Skill> Skills { get; set; }

        public double UseSkill(int nbSkill){
            switch (this.ClassName)
            {
                case "Orc":
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
                case "Necromancian":
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
                case "Gobelin":
                    if (this.Skills[nbSkill].IsEnable)
                    {
                        return (this.Agility + (this.Level - 1) * AgilityPerLevel) * this.Skills[nbSkill].CoefDamages;
                    }
                    else if (this.Skills[nbSkill + 3].IsEnable)
                    {
                        return (this.Agility + (this.Level - 1) * AgilityPerLevel) * this.Skills[nbSkill + 3].CoefDamages;
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