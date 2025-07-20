using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingEngine.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExchangeRateedit12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalFareSYP",
                table: "BookFares");

            migrationBuilder.DropColumn(
                name: "TotalFareUSD",
                table: "BookFares");

            migrationBuilder.RenameColumn(
                name: "TotalFareWithCCFeeUSD",
                table: "BookFares",
                newName: "TotalFare");

            migrationBuilder.RenameColumn(
                name: "TotalFareWithCCFeeSYP",
                table: "BookFares",
                newName: "TotalEquivFare");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalFare",
                table: "BookFares",
                newName: "TotalFareWithCCFeeUSD");

            migrationBuilder.RenameColumn(
                name: "TotalEquivFare",
                table: "BookFares",
                newName: "TotalFareWithCCFeeSYP");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalFareSYP",
                table: "BookFares",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalFareUSD",
                table: "BookFares",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
