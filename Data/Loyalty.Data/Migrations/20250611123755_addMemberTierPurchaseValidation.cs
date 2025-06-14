using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loyalty.Data.Migrations
{
    /// <inheritdoc />
    public partial class addMemberTierPurchaseValidation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MemberTierPurchaseValidation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberTierDetails = table.Column<int>(type: "int", nullable: false),
                    CIS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmountInUsd = table.Column<int>(type: "int", nullable: false),
                    ExtendedValidationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberTierPurchaseValidation", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberTierPurchaseValidation");
        }
    }
}
