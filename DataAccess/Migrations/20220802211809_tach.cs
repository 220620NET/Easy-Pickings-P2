using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class tach : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "middleInit",
                table: "users",
                newName: "middle_init");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "users",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "users",
                newName: "first_name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "middle_init",
                table: "users",
                newName: "middleInit");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "users",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "users",
                newName: "firstName");
        }
    }
}
