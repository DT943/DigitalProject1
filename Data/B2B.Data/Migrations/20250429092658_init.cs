using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2B.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TravelAgentApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TravelAgencyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AccelAeroUserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    POS = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelAgentApplications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TravelAgentOffices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TravelAgentNameISA = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AgencyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SecoundEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    POS = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Governate = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VideoFileCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    VideoFileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageFileCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ImageFileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PdfFileCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PdfFileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ManagerCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SYD = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SYP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelAgentOffices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TravelAgentApplicationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeApplications_TravelAgentApplications_TravelAgentApplicationId",
                        column: x => x.TravelAgentApplicationId,
                        principalTable: "TravelAgentApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TravelAgentEmployee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmployeeRole = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TravelAgentOfficeId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelAgentEmployee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TravelAgentEmployee_TravelAgentOffices_TravelAgentOfficeId",
                        column: x => x.TravelAgentOfficeId,
                        principalTable: "TravelAgentOffices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeApplications_TravelAgentApplicationId",
                table: "EmployeeApplications",
                column: "TravelAgentApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelAgentEmployee_TravelAgentOfficeId",
                table: "TravelAgentEmployee",
                column: "TravelAgentOfficeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeApplications");

            migrationBuilder.DropTable(
                name: "TravelAgentEmployee");

            migrationBuilder.DropTable(
                name: "TravelAgentApplications");

            migrationBuilder.DropTable(
                name: "TravelAgentOffices");
        }
    }
}
