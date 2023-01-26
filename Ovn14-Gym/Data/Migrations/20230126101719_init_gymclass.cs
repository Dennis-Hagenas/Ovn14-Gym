using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ovn14Gym.Data.Migrations
{
    /// <inheritdoc />
    public partial class initgymclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "gymClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gymClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserGymClass",
                columns: table => new
                {
                    ApllicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GymClassId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    GymClassId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserGymClass", x => new { x.ApllicationUserId, x.GymClassId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserGymClass_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationUserGymClass_gymClasses_GymClassId1",
                        column: x => x.GymClassId1,
                        principalTable: "gymClasses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserGymClass_ApplicationUserId",
                table: "ApplicationUserGymClass",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserGymClass_GymClassId1",
                table: "ApplicationUserGymClass",
                column: "GymClassId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserGymClass");

            migrationBuilder.DropTable(
                name: "gymClasses");
        }
    }
}
