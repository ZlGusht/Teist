using Microsoft.EntityFrameworkCore.Migrations;

namespace Teist.Data.Migrations
{
    public partial class artistcreationmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Pieces",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Genre",
                table: "Artists",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Pieces");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Artists");
        }
    }
}
