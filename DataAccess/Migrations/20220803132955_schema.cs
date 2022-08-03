using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class schema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "phone",
                table: "contact",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "double");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "phone",
                table: "contact",
                type: "double",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
