using Microsoft.EntityFrameworkCore.Migrations;

namespace SB.Ball3DTournamentSys.DataAccess.Migrations
{
    public partial class ProtestTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Protests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    PlayedGameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Protests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Protests_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Protests_PlayedGames_PlayedGameId",
                        column: x => x.PlayedGameId,
                        principalTable: "PlayedGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProtestsResponses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProtestId = table.Column<int>(nullable: false),
                    AppUserId = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProtestsResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProtestsResponses_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProtestsResponses_Protests_ProtestId",
                        column: x => x.ProtestId,
                        principalTable: "Protests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Protests_AppUserId",
                table: "Protests",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Protests_PlayedGameId",
                table: "Protests",
                column: "PlayedGameId");

            migrationBuilder.CreateIndex(
                name: "IX_ProtestsResponses_AppUserId",
                table: "ProtestsResponses",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProtestsResponses_ProtestId",
                table: "ProtestsResponses",
                column: "ProtestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProtestsResponses");

            migrationBuilder.DropTable(
                name: "Protests");
        }
    }
}
