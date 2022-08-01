using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class trial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                table: "user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ticket",
                table: "ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_policy",
                table: "policy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_contact",
                table: "contact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_claim",
                table: "claim");

            migrationBuilder.DropColumn(
                name: "contactId",
                table: "user");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "ticket",
                newName: "tickets");

            migrationBuilder.RenameTable(
                name: "policy",
                newName: "policies");

            migrationBuilder.RenameTable(
                name: "contact",
                newName: "contacts");

            migrationBuilder.RenameTable(
                name: "claim",
                newName: "claims");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "userID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tickets",
                table: "tickets",
                column: "ticketID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_policies",
                table: "policies",
                column: "policyID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_contacts",
                table: "contacts",
                column: "contactID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_claims",
                table: "claims",
                column: "claimID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tickets",
                table: "tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_policies",
                table: "policies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_contacts",
                table: "contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_claims",
                table: "claims");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "user");

            migrationBuilder.RenameTable(
                name: "tickets",
                newName: "ticket");

            migrationBuilder.RenameTable(
                name: "policies",
                newName: "policy");

            migrationBuilder.RenameTable(
                name: "contacts",
                newName: "contact");

            migrationBuilder.RenameTable(
                name: "claims",
                newName: "claim");

            migrationBuilder.AddColumn<int>(
                name: "contactId",
                table: "user",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                table: "user",
                column: "userID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ticket",
                table: "ticket",
                column: "ticketID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_policy",
                table: "policy",
                column: "policyID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_contact",
                table: "contact",
                column: "contactID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_claim",
                table: "claim",
                column: "claimID");
        }
    }
}
