﻿// <auto-generated />
using System;
using Groupe3.Dungeon_Crawler.EntitiesContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Groupe3.Dungeon_Crawler.WebApplication.Migrations
{
    [DbContext(typeof(DungeonCrawlerDbContextSql))]
    [Migration("20210205135055_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Groupe3.Dungeon_Crawler.Entity.Character", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<int>("Agility")
                        .HasColumnType("int");

                    b.Property<int>("AgilityPerLevel")
                        .HasColumnType("int");

                    b.Property<int>("BasePv")
                        .HasColumnType("int");

                    b.Property<string>("ClassName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CurrentLife")
                        .HasColumnType("int");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence")
                        .HasColumnType("int");

                    b.Property<int>("IntelligencePerLevel")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<int>("SpeedPerLevel")
                        .HasColumnType("int");

                    b.Property<int>("Stamina")
                        .HasColumnType("int");

                    b.Property<int>("StaminaPerLevel")
                        .HasColumnType("int");

                    b.Property<int>("Strenght")
                        .HasColumnType("int");

                    b.Property<int>("StrenghtPerLevel")
                        .HasColumnType("int");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Character");
                });

            modelBuilder.Entity("Groupe3.Dungeon_Crawler.Entity.Item", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("CharacterId")
                        .HasColumnType("bigint");

                    b.Property<string>("Libelle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("Groupe3.Dungeon_Crawler.Entity.Skill", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("CharacterId")
                        .HasColumnType("bigint");

                    b.Property<double>("CoefDamages")
                        .HasColumnType("float");

                    b.Property<bool>("IsEnable")
                        .HasColumnType("bit");

                    b.Property<int>("LevelToUnlock")
                        .HasColumnType("int");

                    b.Property<int>("LocationSkills")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NbTurnToPrepare")
                        .HasColumnType("int");

                    b.Property<string>("Target")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("Groupe3.Dungeon_Crawler.Entity.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("Mail")
                        .IsUnique()
                        .HasFilter("[Mail] IS NOT NULL");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Groupe3.Dungeon_Crawler.Entity.Character", b =>
                {
                    b.HasOne("Groupe3.Dungeon_Crawler.Entity.User", "User")
                        .WithMany("Characters")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Groupe3.Dungeon_Crawler.Entity.Item", b =>
                {
                    b.HasOne("Groupe3.Dungeon_Crawler.Entity.Character", "Character")
                        .WithMany("Items")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");
                });

            modelBuilder.Entity("Groupe3.Dungeon_Crawler.Entity.Skill", b =>
                {
                    b.HasOne("Groupe3.Dungeon_Crawler.Entity.Character", null)
                        .WithMany("Skills")
                        .HasForeignKey("CharacterId");
                });

            modelBuilder.Entity("Groupe3.Dungeon_Crawler.Entity.Character", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("Groupe3.Dungeon_Crawler.Entity.User", b =>
                {
                    b.Navigation("Characters");
                });
#pragma warning restore 612, 618
        }
    }
}
