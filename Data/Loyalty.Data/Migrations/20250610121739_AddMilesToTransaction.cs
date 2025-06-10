using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loyalty.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMilesToTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Miles",
                table: "MemberAccrualTransactions",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Miles",
                table: "MemberAccrualTransactions");
        }
    }
}
