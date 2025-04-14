using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2B.Data.Migrations
{
    /// <inheritdoc />
    public partial class initapplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TravelAgentApplications",
                schema: "B2B",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TravelAgencyName = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    AccelAeroUserName = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    POS = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelAgentApplications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeApplications",
                schema: "B2B",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EmployeeEmail = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    TravelAgentApplicationId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Code = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeApplications_TravelAgentApplications_TravelAgentApplicationId",
                        column: x => x.TravelAgentApplicationId,
                        principalSchema: "B2B",
                        principalTable: "TravelAgentApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeApplications_TravelAgentApplicationId",
                schema: "B2B",
                table: "EmployeeApplications",
                column: "TravelAgentApplicationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeApplications",
                schema: "B2B");

            migrationBuilder.DropTable(
                name: "TravelAgentApplications",
                schema: "B2B");
        }
    }
}
