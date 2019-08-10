using Microsoft.EntityFrameworkCore.Migrations;

namespace Teist.Data.Migrations
{
    public partial class Configurefinalmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Genre",
                table: "Pieces",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Charts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ChartId",
                table: "Artists",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PieceId",
                table: "Artists",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Genre",
                table: "Albums",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Artists_ChartId",
                table: "Artists",
                column: "ChartId");

            migrationBuilder.CreateIndex(
                name: "IX_Artists_PieceId",
                table: "Artists",
                column: "PieceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Charts_ChartId",
                table: "Artists",
                column: "ChartId",
                principalTable: "Charts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Pieces_PieceId",
                table: "Artists",
                column: "PieceId",
                principalTable: "Pieces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Charts_ChartId",
                table: "Artists");

            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Pieces_PieceId",
                table: "Artists");

            migrationBuilder.DropIndex(
                name: "IX_Artists_ChartId",
                table: "Artists");

            migrationBuilder.DropIndex(
                name: "IX_Artists_PieceId",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Pieces");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Charts");

            migrationBuilder.DropColumn(
                name: "ChartId",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "PieceId",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Albums");
        }
    }
}
