using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2B.Data.Migrations
{
    /// <inheritdoc />
    public partial class addFirstNameandLastNametoEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeFirstName",
                table: "TravelAgentEmployee",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeLastName",
                table: "TravelAgentEmployee",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeFirstName",
                table: "EmployeeApplications",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeLastName",
                table: "EmployeeApplications",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeFirstName",
                table: "TravelAgentEmployee");

            migrationBuilder.DropColumn(
                name: "EmployeeLastName",
                table: "TravelAgentEmployee");

            migrationBuilder.DropColumn(
                name: "EmployeeFirstName",
                table: "EmployeeApplications");

            migrationBuilder.DropColumn(
                name: "EmployeeLastName",
                table: "EmployeeApplications");
        }
    }
}
