using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loyalty.Data.Migrations
{
    /// <inheritdoc />
    public partial class ContinueSegmentMilesDescriptionDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookingClass",
                table: "SegmentMiles",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "COS",
                table: "SegmentMiles",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "SegmentMiles",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingClass",
                table: "SegmentMiles");

            migrationBuilder.DropColumn(
                name: "COS",
                table: "SegmentMiles");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "SegmentMiles");
        }
    }
}
