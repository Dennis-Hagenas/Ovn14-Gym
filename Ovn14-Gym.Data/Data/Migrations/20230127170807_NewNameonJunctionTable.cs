using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ovn14Gym.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewNameonJunctionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserGymClass_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserGymClass");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserGymClass_GymClasses_GymClassId",
                table: "ApplicationUserGymClass");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserGymClass",
                table: "ApplicationUserGymClass");

            migrationBuilder.RenameTable(
                name: "ApplicationUserGymClass",
                newName: "AppUserGymClass");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserGymClass_GymClassId",
                table: "AppUserGymClass",
                newName: "IX_AppUserGymClass_GymClassId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserGymClass_ApplicationUserId",
                table: "AppUserGymClass",
                newName: "IX_AppUserGymClass_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUserGymClass",
                table: "AppUserGymClass",
                columns: new[] { "ApllicationUserId", "GymClassId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserGymClass_AspNetUsers_ApplicationUserId",
                table: "AppUserGymClass",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserGymClass_GymClasses_GymClassId",
                table: "AppUserGymClass",
                column: "GymClassId",
                principalTable: "GymClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserGymClass_AspNetUsers_ApplicationUserId",
                table: "AppUserGymClass");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUserGymClass_GymClasses_GymClassId",
                table: "AppUserGymClass");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUserGymClass",
                table: "AppUserGymClass");

            migrationBuilder.RenameTable(
                name: "AppUserGymClass",
                newName: "ApplicationUserGymClass");

            migrationBuilder.RenameIndex(
                name: "IX_AppUserGymClass_GymClassId",
                table: "ApplicationUserGymClass",
                newName: "IX_ApplicationUserGymClass_GymClassId");

            migrationBuilder.RenameIndex(
                name: "IX_AppUserGymClass_ApplicationUserId",
                table: "ApplicationUserGymClass",
                newName: "IX_ApplicationUserGymClass_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserGymClass",
                table: "ApplicationUserGymClass",
                columns: new[] { "ApllicationUserId", "GymClassId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserGymClass_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserGymClass",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserGymClass_GymClasses_GymClassId",
                table: "ApplicationUserGymClass",
                column: "GymClassId",
                principalTable: "GymClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
