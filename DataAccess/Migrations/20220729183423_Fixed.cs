using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class Fixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FK_policies_users_policyID",
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

            migrationBuilder.DropForeignKey(
                name: "FK_users_contacts_contactId",
                table: "users");

            migrationBuilder.DropTable(
                name: "insurance");

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

            migrationBuilder.RenameIndex(
                name: "IX_users_contactId",
                table: "user",
                newName: "IX_user_contactId");

            migrationBuilder.RenameIndex(
                name: "IX_tickets_userID",
                table: "ticket",
                newName: "IX_ticket_userID");

            migrationBuilder.RenameIndex(
                name: "IX_tickets_policyID",
                table: "ticket",
                newName: "IX_ticket_policyID");

            migrationBuilder.RenameIndex(
                name: "IX_tickets_claimID",
                table: "ticket",
                newName: "IX_ticket_claimID");

            migrationBuilder.RenameIndex(
                name: "IX_claims_userID",
                table: "claim",
                newName: "IX_claim_userID");

            migrationBuilder.RenameIndex(
                name: "IX_claims_policyID",
                table: "claim",
                newName: "IX_claim_policyID");

            migrationBuilder.RenameIndex(
                name: "IX_claims_doctorID",
                table: "claim",
                newName: "IX_claim_doctorID");

            migrationBuilder.AlterColumn<int>(
                name: "contactId",
                table: "user",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "FK_claim_policy_policyID",
                table: "claim",
                column: "policyID",
                principalTable: "policy",
                principalColumn: "policyID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_claim_user_doctorID",
                table: "claim",
                column: "doctorID",
                principalTable: "user",
                principalColumn: "userID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_claim_user_userID",
                table: "claim",
                column: "userID",
                principalTable: "user",
                principalColumn: "userID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_policy_user_policyID",
                table: "policy",
                column: "policyID",
                principalTable: "user",
                principalColumn: "userID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ticket_claim_claimID",
                table: "ticket",
                column: "claimID",
                principalTable: "claim",
                principalColumn: "claimID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ticket_policy_policyID",
                table: "ticket",
                column: "policyID",
                principalTable: "policy",
                principalColumn: "policyID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ticket_user_userID",
                table: "ticket",
                column: "userID",
                principalTable: "user",
                principalColumn: "userID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_contact_contactId",
                table: "user",
                column: "contactId",
                principalTable: "contact",
                principalColumn: "contactID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_claim_policy_policyID",
                table: "claim");

            migrationBuilder.DropForeignKey(
                name: "FK_claim_user_doctorID",
                table: "claim");

            migrationBuilder.DropForeignKey(
                name: "FK_claim_user_userID",
                table: "claim");

            migrationBuilder.DropForeignKey(
                name: "FK_policy_user_policyID",
                table: "policy");

            migrationBuilder.DropForeignKey(
                name: "FK_ticket_claim_claimID",
                table: "ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_ticket_policy_policyID",
                table: "ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_ticket_user_userID",
                table: "ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_user_contact_contactId",
                table: "user");

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

            migrationBuilder.RenameIndex(
                name: "IX_user_contactId",
                table: "users",
                newName: "IX_users_contactId");

            migrationBuilder.RenameIndex(
                name: "IX_ticket_userID",
                table: "tickets",
                newName: "IX_tickets_userID");

            migrationBuilder.RenameIndex(
                name: "IX_ticket_policyID",
                table: "tickets",
                newName: "IX_tickets_policyID");

            migrationBuilder.RenameIndex(
                name: "IX_ticket_claimID",
                table: "tickets",
                newName: "IX_tickets_claimID");

            migrationBuilder.RenameIndex(
                name: "IX_claim_userID",
                table: "claims",
                newName: "IX_claims_userID");

            migrationBuilder.RenameIndex(
                name: "IX_claim_policyID",
                table: "claims",
                newName: "IX_claims_policyID");

            migrationBuilder.RenameIndex(
                name: "IX_claim_doctorID",
                table: "claims",
                newName: "IX_claims_doctorID");

            migrationBuilder.AlterColumn<int>(
                name: "contactId",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.CreateTable(
                name: "insurance",
                columns: table => new
                {
                    insuranceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    benefactor = table.Column<int>(type: "int", nullable: false),
                    provider = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insurance", x => x.insuranceID);
                    table.ForeignKey(
                        name: "FK_insurance_policies_provider",
                        column: x => x.provider,
                        principalTable: "policies",
                        principalColumn: "policyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_insurance_users_benefactor",
                        column: x => x.benefactor,
                        principalTable: "users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_insurance_benefactor",
                table: "insurance",
                column: "benefactor");

            migrationBuilder.CreateIndex(
                name: "IX_insurance_provider",
                table: "insurance",
                column: "provider");

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
                name: "FK_policies_users_policyID",
                table: "policies",
                column: "policyID",
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

            migrationBuilder.AddForeignKey(
                name: "FK_users_contacts_contactId",
                table: "users",
                column: "contactId",
                principalTable: "contacts",
                principalColumn: "contactID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
