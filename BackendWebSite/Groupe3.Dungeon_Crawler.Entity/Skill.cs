namespace Groupe3.Dungeon_Crawler.Entity
{
    public class Skill : Entity
    {
        /// <summary>
        /// Name of the Skill
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Number of turn before the skill is launch
        /// </summary>
        public int NbTurnToPrepare { get; set; }

        /// <summary>
        /// Coef damages of the skill
        /// </summary>
        public double CoefDamages { get; set; }

        /// <summary>
        /// Level when skill is unlocked
        /// </summary>
        public int LevelToUnlock { get; set; }

        /// <summary>
        /// Skill is Single or Multiple target
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// Location of the skill (1,2,3)
        /// </summary>
        public int LocationSkills { get; set; }

        /// <summary>
        /// Skill is usable for the Character
        /// </summary>
        public bool IsEnable { get; set; }
    }
}