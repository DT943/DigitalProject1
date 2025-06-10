using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Audit.Data.Migrations
{
    /// <inheritdoc />
    public partial class auditdatabasr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    controllerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    actionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    request = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    response = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");
        }
    }
}
