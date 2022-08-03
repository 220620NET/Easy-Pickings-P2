using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class contactChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contacts_users_userID",
                table: "contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_contacts",
                table: "contacts");

            migrationBuilder.RenameTable(
                name: "contacts",
                newName: "contact");

            migrationBuilder.RenameColumn(
                name: "streetNumber",
                table: "contact",
                newName: "street_number");

            migrationBuilder.RenameColumn(
                name: "streetName",
                table: "contact",
                newName: "street_name");

            migrationBuilder.RenameColumn(
                name: "cityState",
                table: "contact",
                newName: "city_state");

            migrationBuilder.RenameColumn(
                name: "POorStreet",
                table: "contact",
                newName: "PO_or_street");

            migrationBuilder.RenameColumn(
                name: "PONumber",
                table: "contact",
                newName: "PO_number");

            migrationBuilder.RenameIndex(
                name: "IX_contacts_userID",
                table: "contact",
                newName: "IX_contact_userID");

            migrationBuilder.AlterColumn<long>(
                name: "phone",
                table: "contact",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_contact",
                table: "contact",
                column: "contactID");

            migrationBuilder.AddForeignKey(
                name: "FK_contact_users_userID",
                table: "contact",
                column: "userID",
                principalTable: "users",
                principalColumn: "userID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contact_users_userID",
                table: "contact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_contact",
                table: "contact");

            migrationBuilder.RenameTable(
                name: "contact",
                newName: "contacts");

            migrationBuilder.RenameColumn(
                name: "street_number",
                table: "contacts",
                newName: "streetNumber");

            migrationBuilder.RenameColumn(
                name: "street_name",
                table: "contacts",
                newName: "streetName");

            migrationBuilder.RenameColumn(
                name: "city_state",
                table: "contacts",
                newName: "cityState");

            migrationBuilder.RenameColumn(
                name: "PO_or_street",
                table: "contacts",
                newName: "POorStreet");

            migrationBuilder.RenameColumn(
                name: "PO_number",
                table: "contacts",
                newName: "PONumber");

            migrationBuilder.RenameIndex(
                name: "IX_contact_userID",
                table: "contacts",
                newName: "IX_contacts_userID");

            migrationBuilder.AlterColumn<int>(
                name: "phone",
                table: "contacts",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddPrimaryKey(
                name: "PK_contacts",
                table: "contacts",
                column: "contactID");

            migrationBuilder.AddForeignKey(
                name: "FK_contacts_users_userID",
                table: "contacts",
                column: "userID",
                principalTable: "users",
                principalColumn: "userID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
