using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QueJugadorApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyPlayers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    playerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerPosition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerGroup = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyPlayers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyPlayers");
        }
    }
}
