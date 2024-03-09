using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormulaOne.DataService.Migrations
{
    /// <inheritdoc />
    public partial class addteams : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TeamId",
                table: "Drivers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    FullTeamName = table.Column<string>(type: "TEXT", nullable: false),
                    Base = table.Column<string>(type: "TEXT", nullable: false),
                    TeamChief = table.Column<string>(type: "TEXT", nullable: false),
                    TechnicalChief = table.Column<string>(type: "TEXT", nullable: false),
                    Chassis = table.Column<string>(type: "TEXT", nullable: false),
                    PowerUnit = table.Column<string>(type: "TEXT", nullable: false),
                    FirstTeamEntry = table.Column<string>(type: "TEXT", nullable: false),
                    WorldChampionships = table.Column<int>(type: "INTEGER", nullable: false),
                    HighestRaceFinished = table.Column<int>(type: "INTEGER", nullable: false),
                    TimesHighestRaceFinished = table.Column<int>(type: "INTEGER", nullable: false),
                    PolePositions = table.Column<int>(type: "INTEGER", nullable: false),
                    FastestLaps = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_TeamId",
                table: "Drivers",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Driver",
                table: "Drivers",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_Driver",
                table: "Drivers");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_TeamId",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Drivers");
        }
    }
}
