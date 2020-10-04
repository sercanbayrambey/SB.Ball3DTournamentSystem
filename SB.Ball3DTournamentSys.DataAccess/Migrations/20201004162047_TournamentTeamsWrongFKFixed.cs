using Microsoft.EntityFrameworkCore.Migrations;

namespace SB.Ball3DTournamentSys.DataAccess.Migrations
{
    public partial class TournamentTeamsWrongFKFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TournamentTeams_Teams_TournamentId",
                table: "TournamentTeams");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentTeams_TeamId",
                table: "TournamentTeams",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentTeams_Teams_TeamId",
                table: "TournamentTeams",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TournamentTeams_Teams_TeamId",
                table: "TournamentTeams");

            migrationBuilder.DropIndex(
                name: "IX_TournamentTeams_TeamId",
                table: "TournamentTeams");

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentTeams_Teams_TournamentId",
                table: "TournamentTeams",
                column: "TournamentId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
