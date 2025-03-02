using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Offer.Data.Migrations
{
    /// <inheritdoc />
    public partial class addSegment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketType",
                schema: "OFFER",
                table: "FlightOffers");

            migrationBuilder.RenameColumn(
                name: "UserCode",
                schema: "OFFER",
                table: "Offers",
                newName: "Segment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Segment",
                schema: "OFFER",
                table: "Offers",
                newName: "UserCode");

            migrationBuilder.AddColumn<string>(
                name: "TicketType",
                schema: "OFFER",
                table: "FlightOffers",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");
        }
    }
}
