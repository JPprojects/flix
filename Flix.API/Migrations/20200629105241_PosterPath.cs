using Microsoft.EntityFrameworkCore.Migrations;

namespace Flix.API.Migrations
{
    public partial class PosterPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PosterPath",
                table: "Watchlists",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PosterPath",
                table: "Watchlists");
        }
    }
}
