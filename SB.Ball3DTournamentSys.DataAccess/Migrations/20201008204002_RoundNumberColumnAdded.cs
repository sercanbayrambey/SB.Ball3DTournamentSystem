using Microsoft.EntityFrameworkCore.Migrations;

namespace SB.Ball3DTournamentSys.DataAccess.Migrations
{
    public partial class RoundNumberColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoundNumber",
                table: "PlayedGames",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoundNumber",
                table: "PlayedGames");
        }
    }
}
