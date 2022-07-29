using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class Fixed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_user_contactId",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_ticket_claimID",
                table: "ticket");

            migrationBuilder.DropIndex(
                name: "IX_ticket_policyID",
                table: "ticket");

            migrationBuilder.DropIndex(
                name: "IX_ticket_userID",
                table: "ticket");

            migrationBuilder.DropIndex(
                name: "IX_claim_doctorID",
                table: "claim");

            migrationBuilder.DropIndex(
                name: "IX_claim_policyID",
                table: "claim");

            migrationBuilder.DropIndex(
                name: "IX_claim_userID",
                table: "claim");

            migrationBuilder.AlterColumn<int>(
                name: "policyID",
                table: "policy",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "policyID",
                table: "policy",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_user_contactId",
                table: "user",
                column: "contactId");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_claimID",
                table: "ticket",
                column: "claimID");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_policyID",
                table: "ticket",
                column: "policyID");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_userID",
                table: "ticket",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_claim_doctorID",
                table: "claim",
                column: "doctorID");

            migrationBuilder.CreateIndex(
                name: "IX_claim_policyID",
                table: "claim",
                column: "policyID");

            migrationBuilder.CreateIndex(
                name: "IX_claim_userID",
                table: "claim",
                column: "userID");

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
    }
}
