using Microsoft.EntityFrameworkCore.Migrations;

namespace Teist.Data.Migrations
{
    public partial class testinanotherstrategy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_Artists_PerformerId",
                table: "Pieces");

            migrationBuilder.DropIndex(
                name: "IX_Pieces_PerformerId",
                table: "Pieces");

            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "Pieces",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pieces_ArtistId",
                table: "Pieces",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_Artists_ArtistId",
                table: "Pieces",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_Artists_ArtistId",
                table: "Pieces");

            migrationBuilder.DropIndex(
                name: "IX_Pieces_ArtistId",
                table: "Pieces");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Pieces");

            migrationBuilder.CreateIndex(
                name: "IX_Pieces_PerformerId",
                table: "Pieces",
                column: "PerformerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_Artists_PerformerId",
                table: "Pieces",
                column: "PerformerId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
