using Microsoft.EntityFrameworkCore.Migrations;

namespace Groupe3.Dungeon_Crawler.WebApplication.Migrations
{
    public partial class MaxLife : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "MaxLife",
                table: "Character",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxLife",
                table: "Character");
        }
    }
}
