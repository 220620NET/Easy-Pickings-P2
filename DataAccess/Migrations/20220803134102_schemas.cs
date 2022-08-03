using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class schemas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "users",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "tickets",
                newName: "tickets",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "policies",
                newName: "policies",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "contact",
                newName: "contact",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "claims",
                newName: "claims",
                newSchema: "dbo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "users",
                schema: "dbo",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "tickets",
                schema: "dbo",
                newName: "tickets");

            migrationBuilder.RenameTable(
                name: "policies",
                schema: "dbo",
                newName: "policies");

            migrationBuilder.RenameTable(
                name: "contact",
                schema: "dbo",
                newName: "contact");

            migrationBuilder.RenameTable(
                name: "claims",
                schema: "dbo",
                newName: "claims");
        }
    }
}
