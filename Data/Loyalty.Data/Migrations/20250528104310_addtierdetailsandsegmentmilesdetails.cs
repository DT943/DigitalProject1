using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loyalty.Data.Migrations
{
    /// <inheritdoc />
    public partial class addtierdetailsandsegmentmilesdetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MemberTierDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CIS = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ReversalId = table.Column<int>(type: "int", nullable: true),
                    TierId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UnitTotal = table.Column<int>(type: "int", nullable: true),
                    TXTotal = table.Column<int>(type: "int", nullable: true),
                    FulfillDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TierUpgradeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberTierDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TierDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TireLifeSpanYears = table.Column<int>(type: "int", nullable: false),
                    BonusLifeSpanYears = table.Column<int>(type: "int", nullable: false),
                    BonusAddedValue = table.Column<float>(type: "real", nullable: false),
                    RequiredMilesToReach = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TierDetails", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberTierDetails");

            migrationBuilder.DropTable(
                name: "TierDetails");
        }
    }
}
