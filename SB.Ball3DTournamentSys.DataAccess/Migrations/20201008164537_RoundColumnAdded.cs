using Microsoft.EntityFrameworkCore.Migrations;

namespace SB.Ball3DTournamentSys.DataAccess.Migrations
{
    public partial class RoundColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayedGames_Tournaments_TournamentId",
                table: "PlayedGames");

            migrationBuilder.DropIndex(
                name: "IX_PlayedGames_TournamentId",
                table: "PlayedGames");

            migrationBuilder.DropColumn(
                name: "TournamentId",
                table: "PlayedGames");

            migrationBuilder.AddColumn<int>(
                name: "RoundId",
                table: "PlayedGames",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TournamentBracketRoundEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoundNumber = table.Column<int>(nullable: false),
                    TournamentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentBracketRoundEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TournamentBracketRoundEntity_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayedGames_RoundId",
                table: "PlayedGames",
                column: "RoundId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentBracketRoundEntity_TournamentId",
                table: "TournamentBracketRoundEntity",
                column: "TournamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayedGames_TournamentBracketRoundEntity_RoundId",
                table: "PlayedGames",
                column: "RoundId",
                principalTable: "TournamentBracketRoundEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayedGames_TournamentBracketRoundEntity_RoundId",
                table: "PlayedGames");

            migrationBuilder.DropTable(
                name: "TournamentBracketRoundEntity");

            migrationBuilder.DropIndex(
                name: "IX_PlayedGames_RoundId",
                table: "PlayedGames");

            migrationBuilder.DropColumn(
                name: "RoundId",
                table: "PlayedGames");

            migrationBuilder.AddColumn<int>(
                name: "TournamentId",
                table: "PlayedGames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PlayedGames_TournamentId",
                table: "PlayedGames",
                column: "TournamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayedGames_Tournaments_TournamentId",
                table: "PlayedGames",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
