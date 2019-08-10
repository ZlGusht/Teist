using Microsoft.EntityFrameworkCore.Migrations;

namespace Teist.Data.Migrations
{
    public partial class Finaltouchonentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "Reviews",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Reviews",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChartId",
                table: "Albums",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ArtistId",
                table: "Reviews",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ChartId",
                table: "Albums",
                column: "ChartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Charts_ChartId",
                table: "Albums",
                column: "ChartId",
                principalTable: "Charts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Artists_ArtistId",
                table: "Reviews",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Charts_ChartId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Artists_ArtistId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ArtistId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Albums_ChartId",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ChartId",
                table: "Albums");
        }
    }
}
