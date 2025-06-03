using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loyalty.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMemberRedeptionTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MemberRedemptionTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CIS = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PartnerId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CertificateNum = table.Column<int>(type: "int", nullable: true),
                    Sequence = table.Column<int>(type: "int", nullable: true),
                    UsedMiles = table.Column<int>(type: "int", nullable: false),
                    AwardDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberRedemptionTransactions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberRedemptionTransactions");
        }
    }
}
