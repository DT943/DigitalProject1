using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loyalty.Data.Migrations
{
    /// <inheritdoc />
    public partial class addAmountPaymentInUsd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaidAmountInUsd",
                table: "MemberRedemptionTransactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaidAmountInUsd",
                table: "MemberAccrualTransactions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Complaints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CIS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaints", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Complaints");

            migrationBuilder.DropColumn(
                name: "PaidAmountInUsd",
                table: "MemberRedemptionTransactions");

            migrationBuilder.DropColumn(
                name: "PaidAmountInUsd",
                table: "MemberAccrualTransactions");
        }
    }
}
