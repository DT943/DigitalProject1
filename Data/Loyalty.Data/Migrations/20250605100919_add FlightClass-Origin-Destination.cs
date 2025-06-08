using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loyalty.Data.Migrations
{
    /// <inheritdoc />
    public partial class addFlightClassOriginDestination : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "MemberRedemptionTransactions",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FlightClass",
                table: "MemberRedemptionTransactions",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Origin",
                table: "MemberRedemptionTransactions",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Destination",
                table: "MemberRedemptionTransactions");

            migrationBuilder.DropColumn(
                name: "FlightClass",
                table: "MemberRedemptionTransactions");

            migrationBuilder.DropColumn(
                name: "Origin",
                table: "MemberRedemptionTransactions");
        }
    }
}
