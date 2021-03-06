using Microsoft.EntityFrameworkCore.Migrations;

namespace Groupe3.Dungeon_Crawler.WebApplication.Migrations
{
    public partial class ChangeIntToDoubleForCurrentLife : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "CurrentLife",
                table: "Character",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CurrentLife",
                table: "Character",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
