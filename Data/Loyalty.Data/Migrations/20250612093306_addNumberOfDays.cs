using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loyalty.Data.Migrations
{
    /// <inheritdoc />
    public partial class addNumberOfDays : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfDays",
                table: "MemberTierPurchaseValidation",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfDays",
                table: "MemberTierPurchaseValidation");
        }
    }
}
