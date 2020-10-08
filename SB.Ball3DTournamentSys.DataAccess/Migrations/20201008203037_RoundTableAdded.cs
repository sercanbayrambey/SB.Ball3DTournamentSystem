using Microsoft.EntityFrameworkCore.Migrations;

namespace SB.Ball3DTournamentSys.DataAccess.Migrations
{
    public partial class RoundTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayedGames_TournamentBracketRoundEntity_RoundId",
                table: "PlayedGames");

            migrationBuilder.DropForeignKey(
                name: "FK_TournamentBracketRoundEntity_Tournaments_TournamentId",
                table: "TournamentBracketRoundEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TournamentBracketRoundEntity",
                table: "TournamentBracketRoundEntity");

            migrationBuilder.RenameTable(
                name: "TournamentBracketRoundEntity",
                newName: "TournamentBracketRounds");

            migrationBuilder.RenameIndex(
                name: "IX_TournamentBracketRoundEntity_TournamentId",
                table: "TournamentBracketRounds",
                newName: "IX_TournamentBracketRounds_TournamentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TournamentBracketRounds",
                table: "TournamentBracketRounds",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayedGames_TournamentBracketRounds_RoundId",
                table: "PlayedGames",
                column: "RoundId",
                principalTable: "TournamentBracketRounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentBracketRounds_Tournaments_TournamentId",
                table: "TournamentBracketRounds",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayedGames_TournamentBracketRounds_RoundId",
                table: "PlayedGames");

            migrationBuilder.DropForeignKey(
                name: "FK_TournamentBracketRounds_Tournaments_TournamentId",
                table: "TournamentBracketRounds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TournamentBracketRounds",
                table: "TournamentBracketRounds");

            migrationBuilder.RenameTable(
                name: "TournamentBracketRounds",
                newName: "TournamentBracketRoundEntity");

            migrationBuilder.RenameIndex(
                name: "IX_TournamentBracketRounds_TournamentId",
                table: "TournamentBracketRoundEntity",
                newName: "IX_TournamentBracketRoundEntity_TournamentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TournamentBracketRoundEntity",
                table: "TournamentBracketRoundEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayedGames_TournamentBracketRoundEntity_RoundId",
                table: "PlayedGames",
                column: "RoundId",
                principalTable: "TournamentBracketRoundEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentBracketRoundEntity_Tournaments_TournamentId",
                table: "TournamentBracketRoundEntity",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
