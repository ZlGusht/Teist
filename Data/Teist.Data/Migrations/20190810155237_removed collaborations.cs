using Microsoft.EntityFrameworkCore.Migrations;

namespace Teist.Data.Migrations
{
    public partial class removedcollaborations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Artists_PerformerId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Albums_AlbumId",
                table: "Artists");

            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Pieces_PieceId",
                table: "Artists");

            migrationBuilder.DropForeignKey(
                name: "FK_Charts_Albums_AlbumId",
                table: "Charts");

            migrationBuilder.DropIndex(
                name: "IX_Charts_AlbumId",
                table: "Charts");

            migrationBuilder.DropIndex(
                name: "IX_Artists_AlbumId",
                table: "Artists");

            migrationBuilder.DropIndex(
                name: "IX_Artists_PieceId",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "PerformerId",
                table: "Pieces");

            migrationBuilder.DropColumn(
                name: "AlbumId",
                table: "Charts");

            migrationBuilder.DropColumn(
                name: "AlbumId",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "PieceId",
                table: "Artists");

            migrationBuilder.RenameColumn(
                name: "PerformerId",
                table: "Albums",
                newName: "ArtistId");

            migrationBuilder.RenameIndex(
                name: "IX_Albums_PerformerId",
                table: "Albums",
                newName: "IX_Albums_ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Artists_ArtistId",
                table: "Albums",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Artists_ArtistId",
                table: "Albums");

            migrationBuilder.RenameColumn(
                name: "ArtistId",
                table: "Albums",
                newName: "PerformerId");

            migrationBuilder.RenameIndex(
                name: "IX_Albums_ArtistId",
                table: "Albums",
                newName: "IX_Albums_PerformerId");

            migrationBuilder.AddColumn<int>(
                name: "PerformerId",
                table: "Pieces",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AlbumId",
                table: "Charts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AlbumId",
                table: "Artists",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PieceId",
                table: "Artists",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Charts_AlbumId",
                table: "Charts",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Artists_AlbumId",
                table: "Artists",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Artists_PieceId",
                table: "Artists",
                column: "PieceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Artists_PerformerId",
                table: "Albums",
                column: "PerformerId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Albums_AlbumId",
                table: "Artists",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Pieces_PieceId",
                table: "Artists",
                column: "PieceId",
                principalTable: "Pieces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Charts_Albums_AlbumId",
                table: "Charts",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
