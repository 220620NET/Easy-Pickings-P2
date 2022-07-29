using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class trials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "userID",
                table: "contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tickets_claimID",
                table: "tickets",
                column: "claimID");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_policyID",
                table: "tickets",
                column: "policyID");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_userID",
                table: "tickets",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_policies_insurance",
                table: "policies",
                column: "insurance");

            migrationBuilder.CreateIndex(
                name: "IX_contacts_userID",
                table: "contacts",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_claims_doctorID",
                table: "claims",
                column: "doctorID");

            migrationBuilder.CreateIndex(
                name: "IX_claims_policyID",
                table: "claims",
                column: "policyID");

            migrationBuilder.CreateIndex(
                name: "IX_claims_userID",
                table: "claims",
                column: "userID");

            migrationBuilder.AddForeignKey(
                name: "FK_claims_policies_policyID",
                table: "claims",
                column: "policyID",
                principalTable: "policies",
                principalColumn: "policyID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_claims_users_doctorID",
                table: "claims",
                column: "doctorID",
                principalTable: "users",
                principalColumn: "userID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_claims_users_userID",
                table: "claims",
                column: "userID",
                principalTable: "users",
                principalColumn: "userID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_contacts_users_userID",
                table: "contacts",
                column: "userID",
                principalTable: "users",
                principalColumn: "userID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_policies_users_insurance",
                table: "policies",
                column: "insurance",
                principalTable: "users",
                principalColumn: "userID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_claims_claimID",
                table: "tickets",
                column: "claimID",
                principalTable: "claims",
                principalColumn: "claimID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_policies_policyID",
                table: "tickets",
                column: "policyID",
                principalTable: "policies",
                principalColumn: "policyID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_users_userID",
                table: "tickets",
                column: "userID",
                principalTable: "users",
                principalColumn: "userID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_claims_policies_policyID",
                table: "claims");

            migrationBuilder.DropForeignKey(
                name: "FK_claims_users_doctorID",
                table: "claims");

            migrationBuilder.DropForeignKey(
                name: "FK_claims_users_userID",
                table: "claims");

            migrationBuilder.DropForeignKey(
                name: "FK_contacts_users_userID",
                table: "contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_policies_users_insurance",
                table: "policies");

            migrationBuilder.DropForeignKey(
                name: "FK_tickets_claims_claimID",
                table: "tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_tickets_policies_policyID",
                table: "tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_tickets_users_userID",
                table: "tickets");

            migrationBuilder.DropIndex(
                name: "IX_tickets_claimID",
                table: "tickets");

            migrationBuilder.DropIndex(
                name: "IX_tickets_policyID",
                table: "tickets");

            migrationBuilder.DropIndex(
                name: "IX_tickets_userID",
                table: "tickets");

            migrationBuilder.DropIndex(
                name: "IX_policies_insurance",
                table: "policies");

            migrationBuilder.DropIndex(
                name: "IX_contacts_userID",
                table: "contacts");

            migrationBuilder.DropIndex(
                name: "IX_claims_doctorID",
                table: "claims");

            migrationBuilder.DropIndex(
                name: "IX_claims_policyID",
                table: "claims");

            migrationBuilder.DropIndex(
                name: "IX_claims_userID",
                table: "claims");

            migrationBuilder.DropColumn(
                name: "userID",
                table: "contacts");
        }
    }
}
