using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ovn14Gym.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixspelling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserGymClass_AspNetUsers_ApplicationUserId",
                table: "AppUserGymClass");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUserGymClass",
                table: "AppUserGymClass");

            migrationBuilder.DropIndex(
                name: "IX_AppUserGymClass_ApplicationUserId",
                table: "AppUserGymClass");

            migrationBuilder.DropColumn(
                name: "ApllicationUserId",
                table: "AppUserGymClass");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "AppUserGymClass",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUserGymClass",
                table: "AppUserGymClass",
                columns: new[] { "ApplicationUserId", "GymClassId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserGymClass_AspNetUsers_ApplicationUserId",
                table: "AppUserGymClass",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserGymClass_AspNetUsers_ApplicationUserId",
                table: "AppUserGymClass");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUserGymClass",
                table: "AppUserGymClass");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "AppUserGymClass",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ApllicationUserId",
                table: "AppUserGymClass",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUserGymClass",
                table: "AppUserGymClass",
                columns: new[] { "ApllicationUserId", "GymClassId" });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserGymClass_ApplicationUserId",
                table: "AppUserGymClass",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserGymClass_AspNetUsers_ApplicationUserId",
                table: "AppUserGymClass",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
