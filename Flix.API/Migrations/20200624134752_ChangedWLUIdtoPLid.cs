using Microsoft.EntityFrameworkCore.Migrations;

namespace Flix.API.Migrations
{
    public partial class ChangedWLUIdtoPLid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Watchlists_Playlists_UserId",
                table: "Watchlists");

            migrationBuilder.DropIndex(
                name: "IX_Watchlists_UserId",
                table: "Watchlists");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Watchlists");

            migrationBuilder.AddColumn<int>(
                name: "PlaylistId",
                table: "Watchlists",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Watchlists_PlaylistId",
                table: "Watchlists",
                column: "PlaylistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Watchlists_Playlists_PlaylistId",
                table: "Watchlists",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Watchlists_Playlists_PlaylistId",
                table: "Watchlists");

            migrationBuilder.DropIndex(
                name: "IX_Watchlists_PlaylistId",
                table: "Watchlists");

            migrationBuilder.DropColumn(
                name: "PlaylistId",
                table: "Watchlists");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Watchlists",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Watchlists_UserId",
                table: "Watchlists",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Watchlists_Playlists_UserId",
                table: "Watchlists",
                column: "UserId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
