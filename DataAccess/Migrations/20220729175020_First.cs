using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    contactID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    POorStreet = table.Column<bool>(type: "bit", nullable: false),
                    PONumber = table.Column<int>(type: "int", nullable: false),
                    streetNumber = table.Column<int>(type: "int", nullable: false),
                    streetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cityState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    zipcode = table.Column<int>(type: "int", nullable: false),
                    phone = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.contactID);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    userID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    middleInit = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    contactId = table.Column<int>(type: "int", nullable: false),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.userID);
                    table.ForeignKey(
                        name: "FK_users_contacts_contactId",
                        column: x => x.contactId,
                        principalTable: "contacts",
                        principalColumn: "contactID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "policies",
                columns: table => new
                {
                    policyID = table.Column<int>(type: "int", nullable: false),
                    insurance = table.Column<int>(type: "int", nullable: false),
                    coverage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_policies", x => x.policyID);
                    table.ForeignKey(
                        name: "FK_policies_users_policyID",
                        column: x => x.policyID,
                        principalTable: "users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "claims",
                columns: table => new
                {
                    claimID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userID = table.Column<int>(type: "int", nullable: false),
                    doctorID = table.Column<int>(type: "int", nullable: false),
                    policyID = table.Column<int>(type: "int", nullable: false),
                    reasonForVisit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_claims", x => x.claimID);
                    table.ForeignKey(
                        name: "FK_claims_policies_policyID",
                        column: x => x.policyID,
                        principalTable: "policies",
                        principalColumn: "policyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_claims_users_doctorID",
                        column: x => x.doctorID,
                        principalTable: "users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_claims_users_userID",
                        column: x => x.userID,
                        principalTable: "users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "insurance",
                columns: table => new
                {
                    insuranceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    provider = table.Column<int>(type: "int", nullable: false),
                    benefactor = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "tickets",
                columns: table => new
                {
                    ticketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    claimID = table.Column<int>(type: "int", nullable: false),
                    userID = table.Column<int>(type: "int", nullable: false),
                    policyID = table.Column<int>(type: "int", nullable: false),
                    details = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tickets", x => x.ticketID);
                    table.ForeignKey(
                        name: "FK_tickets_claims_claimID",
                        column: x => x.claimID,
                        principalTable: "claims",
                        principalColumn: "claimID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tickets_policies_policyID",
                        column: x => x.policyID,
                        principalTable: "policies",
                        principalColumn: "policyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tickets_users_userID",
                        column: x => x.userID,
                        principalTable: "users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_insurance_benefactor",
                table: "insurance",
                column: "benefactor");

            migrationBuilder.CreateIndex(
                name: "IX_insurance_provider",
                table: "insurance",
                column: "provider");

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
                name: "IX_users_contactId",
                table: "users",
                column: "contactId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "insurance");

            migrationBuilder.DropTable(
                name: "tickets");

            migrationBuilder.DropTable(
                name: "claims");

            migrationBuilder.DropTable(
                name: "policies");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "contacts");
        }
    }
}
