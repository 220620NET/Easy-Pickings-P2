using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class schemas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "P2");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "P2",
                columns: table => new
                {
                    userID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    middle_init = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userID);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                schema: "P2",
                columns: table => new
                {
                    contactID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PO_or_street = table.Column<bool>(type: "bit", nullable: false),
                    PO_number = table.Column<int>(type: "int", nullable: false),
                    street_number = table.Column<int>(type: "int", nullable: false),
                    street_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city_state = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    zipcode = table.Column<int>(type: "int", nullable: false),
                    userID = table.Column<int>(type: "int", nullable: false),
                    phone = table.Column<long>(type: "bigint", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.contactID);
                    table.ForeignKey(
                        name: "FK_Contacts_Users_userID",
                        column: x => x.userID,
                        principalSchema: "P2",
                        principalTable: "Users",
                        principalColumn: "userID");
                });

            migrationBuilder.CreateTable(
                name: "Policies",
                schema: "P2",
                columns: table => new
                {
                    policyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    insurance = table.Column<int>(type: "int", nullable: false),
                    coverage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.policyID);
                    table.ForeignKey(
                        name: "FK_Policies_Users_insurance",
                        column: x => x.insurance,
                        principalSchema: "P2",
                        principalTable: "Users",
                        principalColumn: "userID");
                });

            migrationBuilder.CreateTable(
                name: "Claims",
                schema: "P2",
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
                    table.PrimaryKey("PK_Claims", x => x.claimID);
                    table.ForeignKey(
                        name: "FK_Claims_Policies_policyID",
                        column: x => x.policyID,
                        principalSchema: "P2",
                        principalTable: "Policies",
                        principalColumn: "policyID");
                    table.ForeignKey(
                        name: "FK_Claims_Users_doctorID",
                        column: x => x.doctorID,
                        principalSchema: "P2",
                        principalTable: "Users",
                        principalColumn: "userID");
                    table.ForeignKey(
                        name: "FK_Claims_Users_userID",
                        column: x => x.userID,
                        principalSchema: "P2",
                        principalTable: "Users",
                        principalColumn: "userID");
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                schema: "P2",
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
                    table.PrimaryKey("PK_Tickets", x => x.ticketID);
                    table.ForeignKey(
                        name: "FK_Tickets_Claims_claimID",
                        column: x => x.claimID,
                        principalSchema: "P2",
                        principalTable: "Claims",
                        principalColumn: "claimID");
                    table.ForeignKey(
                        name: "FK_Tickets_Policies_policyID",
                        column: x => x.policyID,
                        principalSchema: "P2",
                        principalTable: "Policies",
                        principalColumn: "policyID");
                    table.ForeignKey(
                        name: "FK_Tickets_Users_userID",
                        column: x => x.userID,
                        principalSchema: "P2",
                        principalTable: "Users",
                        principalColumn: "userID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Claims_doctorID",
                schema: "P2",
                table: "Claims",
                column: "doctorID");

            migrationBuilder.CreateIndex(
                name: "IX_Claims_policyID",
                schema: "P2",
                table: "Claims",
                column: "policyID");

            migrationBuilder.CreateIndex(
                name: "IX_Claims_userID",
                schema: "P2",
                table: "Claims",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_userID",
                schema: "P2",
                table: "Contacts",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Policies_insurance",
                schema: "P2",
                table: "Policies",
                column: "insurance");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_claimID",
                schema: "P2",
                table: "Tickets",
                column: "claimID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_policyID",
                schema: "P2",
                table: "Tickets",
                column: "policyID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_userID",
                schema: "P2",
                table: "Tickets",
                column: "userID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts",
                schema: "P2");

            migrationBuilder.DropTable(
                name: "Tickets",
                schema: "P2");

            migrationBuilder.DropTable(
                name: "Claims",
                schema: "P2");

            migrationBuilder.DropTable(
                name: "Policies",
                schema: "P2");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "P2");
        }
    }
}
