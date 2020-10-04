using Microsoft.EntityFrameworkCore.Migrations;

namespace SB.Ball3DTournamentSys.DataAccess.Migrations
{
    public partial class AddedColumnAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Teams",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "TeamPlayers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_AppUserId",
                table: "Teams",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamPlayers_AppUserId",
                table: "TeamPlayers",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamPlayers_AspNetUsers_AppUserId",
                table: "TeamPlayers",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_AspNetUsers_AppUserId",
                table: "Teams",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamPlayers_AspNetUsers_AppUserId",
                table: "TeamPlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_AspNetUsers_AppUserId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_AppUserId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_TeamPlayers_AppUserId",
                table: "TeamPlayers");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "TeamPlayers");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "AspNetUsers");
        }
    }
}
