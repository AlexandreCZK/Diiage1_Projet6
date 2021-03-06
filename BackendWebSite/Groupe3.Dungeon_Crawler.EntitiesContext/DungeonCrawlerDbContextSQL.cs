using Groupe3.Dungeon_Crawler.Entity;
using Microsoft.EntityFrameworkCore;

namespace Groupe3.Dungeon_Crawler.EntitiesContext
{
    public class DungeonCrawlerDbContextSql : DbContext
    {
        public DungeonCrawlerDbContextSql(DbContextOptions<DungeonCrawlerDbContextSql> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Character>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Item>()
                .HasKey(i => i.Id);
            modelBuilder.Entity<Item>()
                .Property(i => i.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Skill>()
                .HasKey(s => s.Id);
            modelBuilder.Entity<Skill>()
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<UserFriend>()
               .HasKey(u => u.Id);
            modelBuilder.Entity<UserFriend>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Mail)
                .IsUnique();

            modelBuilder.Entity<Character>()
                .HasOne(c => c.User)
                .WithMany(u => u.Characters)
                .HasForeignKey(c => c.UserId);
            modelBuilder.Entity<Item>()
                .HasOne(i => i.Character)
                .WithMany(c => c.Items)
                .HasForeignKey(x => x.CharacterId);

            modelBuilder.Entity<UserFriend>()
                .HasOne(f => f.User)
                .WithMany()
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserFriend>()
                .HasOne(f => f.Friend)
                .WithMany()
                .HasForeignKey(f => f.FriendId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
