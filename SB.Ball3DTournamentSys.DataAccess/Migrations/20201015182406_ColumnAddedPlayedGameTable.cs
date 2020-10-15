using Microsoft.EntityFrameworkCore.Migrations;

namespace SB.Ball3DTournamentSys.DataAccess.Migrations
{
    public partial class ColumnAddedPlayedGameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAwayTeamConfirmedResult",
                table: "PlayedGames",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHomeTeamConfirmedResult",
                table: "PlayedGames",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAwayTeamConfirmedResult",
                table: "PlayedGames");

            migrationBuilder.DropColumn(
                name: "IsHomeTeamConfirmedResult",
                table: "PlayedGames");
        }
    }
}
