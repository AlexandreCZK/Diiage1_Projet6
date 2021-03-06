namespace Groupe3.Dungeon_Crawler.Entity
{
    public class Item : Entity
    {
        /// <summary>
        /// Libelle of the item (heal, xp)
        /// </summary>
        public string Libelle { get; set; }

        /// <summary>
        /// Contain the value who give the item (50 health for heal, 50xp for xp)
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Charactre who possess this item
        /// </summary>
        public Character Character { get; set; }

        /// <summary>
        /// CharactreId who possess this item
        /// </summary>
        public long CharacterId { get; set; }
    }
}
