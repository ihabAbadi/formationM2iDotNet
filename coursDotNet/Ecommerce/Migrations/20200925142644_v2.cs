using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Erole_RoleId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Erole",
                table: "Erole");

            migrationBuilder.RenameTable(
                name: "Erole",
                newName: "Roles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Erole");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Erole",
                table: "Erole",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Erole_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Erole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
