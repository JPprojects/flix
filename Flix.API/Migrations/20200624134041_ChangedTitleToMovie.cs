using Microsoft.EntityFrameworkCore.Migrations;

namespace Flix.API.Migrations
{
    public partial class ChangedTitleToMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Watchlists");

            migrationBuilder.AddColumn<string>(
                name: "MovieTitle",
                table: "Watchlists",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieTitle",
                table: "Watchlists");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Watchlists",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
