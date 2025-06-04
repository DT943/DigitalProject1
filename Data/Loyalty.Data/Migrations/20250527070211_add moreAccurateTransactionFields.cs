using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loyalty.Data.Migrations
{
    /// <inheritdoc />
    public partial class addmoreAccurateTransactionFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookClass",
                table: "MemberAccrualTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarrierCode",
                table: "MemberAccrualTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CouponNumber",
                table: "MemberAccrualTransactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "MemberAccrualTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FlightClass",
                table: "MemberAccrualTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FlightNumber",
                table: "MemberAccrualTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Origin",
                table: "MemberAccrualTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TicketNumber",
                table: "MemberAccrualTransactions",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookClass",
                table: "MemberAccrualTransactions");

            migrationBuilder.DropColumn(
                name: "CarrierCode",
                table: "MemberAccrualTransactions");

            migrationBuilder.DropColumn(
                name: "CouponNumber",
                table: "MemberAccrualTransactions");

            migrationBuilder.DropColumn(
                name: "Destination",
                table: "MemberAccrualTransactions");

            migrationBuilder.DropColumn(
                name: "FlightClass",
                table: "MemberAccrualTransactions");

            migrationBuilder.DropColumn(
                name: "FlightNumber",
                table: "MemberAccrualTransactions");

            migrationBuilder.DropColumn(
                name: "Origin",
                table: "MemberAccrualTransactions");

            migrationBuilder.DropColumn(
                name: "TicketNumber",
                table: "MemberAccrualTransactions");
        }
    }
}
