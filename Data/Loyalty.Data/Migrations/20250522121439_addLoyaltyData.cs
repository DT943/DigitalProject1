using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loyalty.Data.Migrations
{
    /// <inheritdoc />
    public partial class addLoyaltyData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MemberAccrualTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CIS = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PartnerCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LoadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Base = table.Column<int>(type: "int", nullable: true),
                    Bonus = table.Column<int>(type: "int", nullable: true),
                    ActDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActValue = table.Column<float>(type: "real", nullable: true),
                    ReversalId = table.Column<int>(type: "int", nullable: true),
                    TierId = table.Column<int>(type: "int", nullable: true),
                    LoadType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STMTDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActInvNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    INVDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    STMTNo = table.Column<int>(type: "int", nullable: true),
                    INVNo = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberAccrualTransactions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberAccrualTransactions");
        }
    }
}
