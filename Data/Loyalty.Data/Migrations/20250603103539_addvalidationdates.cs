using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loyalty.Data.Migrations
{
    /// <inheritdoc />
    public partial class addvalidationdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RedemptionValue",
                table: "MemberTransactionRedemptionDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "BonusValidationDate",
                table: "MemberAccrualTransactions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TierValidationDate",
                table: "MemberAccrualTransactions",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RedemptionValue",
                table: "MemberTransactionRedemptionDetails");

            migrationBuilder.DropColumn(
                name: "BonusValidationDate",
                table: "MemberAccrualTransactions");

            migrationBuilder.DropColumn(
                name: "TierValidationDate",
                table: "MemberAccrualTransactions");
        }
    }
}
