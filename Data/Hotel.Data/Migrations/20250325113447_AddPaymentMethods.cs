using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentMethods : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountName",
                schema: "HOTEL",
                table: "Hotels",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                schema: "HOTEL",
                table: "Hotels",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalInfo",
                schema: "HOTEL",
                table: "Hotels",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankName",
                schema: "HOTEL",
                table: "Hotels",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "BankTransfer",
                schema: "HOTEL",
                table: "Hotels",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "BranchName",
                schema: "HOTEL",
                table: "Hotels",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Cash",
                schema: "HOTEL",
                table: "Hotels",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CreditCard",
                schema: "HOTEL",
                table: "Hotels",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CryptoCurrency",
                schema: "HOTEL",
                table: "Hotels",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DebitCard",
                schema: "HOTEL",
                table: "Hotels",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IBAN",
                schema: "HOTEL",
                table: "Hotels",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MobilePayment",
                schema: "HOTEL",
                table: "Hotels",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PayPal",
                schema: "HOTEL",
                table: "Hotels",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SWIFTCode",
                schema: "HOTEL",
                table: "Hotels",
                type: "NVARCHAR2(2000)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountName",
                schema: "HOTEL",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "AccountNumber",
                schema: "HOTEL",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "AdditionalInfo",
                schema: "HOTEL",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "BankName",
                schema: "HOTEL",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "BankTransfer",
                schema: "HOTEL",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "BranchName",
                schema: "HOTEL",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Cash",
                schema: "HOTEL",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "CreditCard",
                schema: "HOTEL",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "CryptoCurrency",
                schema: "HOTEL",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "DebitCard",
                schema: "HOTEL",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "IBAN",
                schema: "HOTEL",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "MobilePayment",
                schema: "HOTEL",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "PayPal",
                schema: "HOTEL",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "SWIFTCode",
                schema: "HOTEL",
                table: "Hotels");
        }
    }
}
