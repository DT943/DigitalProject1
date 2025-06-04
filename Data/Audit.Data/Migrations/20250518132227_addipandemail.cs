using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Audit.Data.Migrations
{
    /// <inheritdoc />
    public partial class addipandemail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "AuditLogs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IP",
                table: "AuditLogs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "AuditLogs");

            migrationBuilder.DropColumn(
                name: "IP",
                table: "AuditLogs");
        }
    }
}
