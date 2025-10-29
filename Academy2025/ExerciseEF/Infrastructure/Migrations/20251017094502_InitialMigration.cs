using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "GameList",
                columns: table => new
                {
                    GameListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameListName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameList", x => x.GameListId);
                    table.ForeignKey(
                        name: "FK_GameList_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<int>(type: "int", nullable: false),
                    GameplayHours = table.Column<int>(type: "int", nullable: false),
                    Studio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                    table.ForeignKey(
                        name: "FK_Games_GameList_GameListId",
                        column: x => x.GameListId,
                        principalTable: "GameList",
                        principalColumn: "GameListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName" },
                values: new object[] { 1, "john@example.com", "John", "Doe" });

            migrationBuilder.InsertData(
                table: "GameList",
                columns: new[] { "GameListId", "GameListName", "UserId" },
                values: new object[] { 1, "Backlog", 1 });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "GameListId", "GameName", "GameplayHours", "Genre", "Studio" },
                values: new object[] { 1, 1, "Portal", 8, 6, "Valve" });

            migrationBuilder.CreateIndex(
                name: "IX_GameList_UserId",
                table: "GameList",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_GameListId",
                table: "Games",
                column: "GameListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "GameList");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
