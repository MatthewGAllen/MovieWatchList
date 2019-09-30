using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieWatchList.Migrations
{
    public partial class addStarToModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Star",
                table: "MovieInfo",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Star",
                table: "MovieInfo");
        }
    }
}
