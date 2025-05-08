using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2B.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_names_to_pos_and_agentcode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelAgentEmployee_TravelAgentOffices_TravelAgentOfficeId",
                table: "TravelAgentEmployee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TravelAgentEmployee",
                table: "TravelAgentEmployee");

            migrationBuilder.RenameTable(
                name: "TravelAgentEmployee",
                newName: "TravelAgentEmployees");

            migrationBuilder.RenameIndex(
                name: "IX_TravelAgentEmployee_TravelAgentOfficeId",
                table: "TravelAgentEmployees",
                newName: "IX_TravelAgentEmployees_TravelAgentOfficeId");

            migrationBuilder.AlterColumn<string>(
                name: "POS",
                table: "TravelAgentPOS",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TravelAgentPOS",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AccellAeroUserName",
                table: "TravelAgentOffices",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TravelAgentEmployees",
                table: "TravelAgentEmployees",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelAgentEmployees_TravelAgentOffices_TravelAgentOfficeId",
                table: "TravelAgentEmployees",
                column: "TravelAgentOfficeId",
                principalTable: "TravelAgentOffices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelAgentEmployees_TravelAgentOffices_TravelAgentOfficeId",
                table: "TravelAgentEmployees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TravelAgentEmployees",
                table: "TravelAgentEmployees");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "TravelAgentPOS");

            migrationBuilder.DropColumn(
                name: "AccellAeroUserName",
                table: "TravelAgentOffices");

            migrationBuilder.RenameTable(
                name: "TravelAgentEmployees",
                newName: "TravelAgentEmployee");

            migrationBuilder.RenameIndex(
                name: "IX_TravelAgentEmployees_TravelAgentOfficeId",
                table: "TravelAgentEmployee",
                newName: "IX_TravelAgentEmployee_TravelAgentOfficeId");

            migrationBuilder.AlterColumn<string>(
                name: "POS",
                table: "TravelAgentPOS",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TravelAgentEmployee",
                table: "TravelAgentEmployee",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelAgentEmployee_TravelAgentOffices_TravelAgentOfficeId",
                table: "TravelAgentEmployee",
                column: "TravelAgentOfficeId",
                principalTable: "TravelAgentOffices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
