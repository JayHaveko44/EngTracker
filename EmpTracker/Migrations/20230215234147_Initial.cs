using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpTracker.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkLocation",
                columns: table => new
                {
                    WorkLocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkLocation", x => x.WorkLocationId);
                });

            migrationBuilder.CreateTable(
                name: "Engineer",
                columns: table => new
                {
                    EngineerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsWorking = table.Column<bool>(type: "bit", nullable: false),
                    WorkingLocationWorkLocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engineer", x => x.EngineerId);
                    table.ForeignKey(
                        name: "FK_Engineer_WorkLocation_WorkingLocationWorkLocationId",
                        column: x => x.WorkingLocationWorkLocationId,
                        principalTable: "WorkLocation",
                        principalColumn: "WorkLocationId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Engineer_WorkingLocationWorkLocationId",
                table: "Engineer",
                column: "WorkingLocationWorkLocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Engineer");

            migrationBuilder.DropTable(
                name: "WorkLocation");
        }
    }
}
