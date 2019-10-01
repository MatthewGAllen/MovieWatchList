using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieWatchList.Migrations
{
    public partial class addForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MovieInfo",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovieInfo_UserId",
                table: "MovieInfo",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieInfo_AspNetUsers_UserId",
                table: "MovieInfo",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieInfo_AspNetUsers_UserId",
                table: "MovieInfo");

            migrationBuilder.DropIndex(
                name: "IX_MovieInfo_UserId",
                table: "MovieInfo");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MovieInfo");
        }
    }
}
