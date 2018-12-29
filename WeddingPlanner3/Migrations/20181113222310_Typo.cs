using Microsoft.EntityFrameworkCore.Migrations;

namespace WeddingPlanner3.Migrations
{
    public partial class Typo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weddings_Users_userID",
                table: "Weddings");

            migrationBuilder.RenameColumn(
                name: "userID",
                table: "Weddings",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Weddings_userID",
                table: "Weddings",
                newName: "IX_Weddings_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Weddings_Users_UserID",
                table: "Weddings",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weddings_Users_UserID",
                table: "Weddings");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Weddings",
                newName: "userID");

            migrationBuilder.RenameIndex(
                name: "IX_Weddings_UserID",
                table: "Weddings",
                newName: "IX_Weddings_userID");

            migrationBuilder.AddForeignKey(
                name: "FK_Weddings_Users_userID",
                table: "Weddings",
                column: "userID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
