using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Offer.Data.Migrations
{
    /// <inheritdoc />
    public partial class offerservice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "OFFER");

            migrationBuilder.CreateTable(
                name: "FlightOffers",
                schema: "OFFER",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferID = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    POS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TripType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfferFor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightOffers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HolidayOffers",
                schema: "OFFER",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferID = table.Column<int>(type: "int", nullable: false),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    POS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsIndiv = table.Column<bool>(type: "bit", nullable: false),
                    IsFamily = table.Column<bool>(type: "bit", nullable: false),
                    IsHoneyMoon = table.Column<bool>(type: "bit", nullable: false),
                    IsMedical = table.Column<bool>(type: "bit", nullable: false),
                    IsLuxury = table.Column<bool>(type: "bit", nullable: false),
                    IsPremium = table.Column<bool>(type: "bit", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolidayOffers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                schema: "OFFER",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Segment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Membership = table.Column<bool>(type: "bit", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LuxuryHoliday",
                schema: "OFFER",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HolidayOfferId = table.Column<int>(type: "int", nullable: false),
                    FlightOfferId = table.Column<int>(type: "int", nullable: false),
                    Transportation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LuxuryHoliday", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LuxuryHoliday_FlightOffers_FlightOfferId",
                        column: x => x.FlightOfferId,
                        principalSchema: "OFFER",
                        principalTable: "FlightOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LuxuryHoliday_HolidayOffers_HolidayOfferId",
                        column: x => x.HolidayOfferId,
                        principalSchema: "OFFER",
                        principalTable: "HolidayOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PremiumHoliday",
                schema: "OFFER",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HolidayOfferId = table.Column<int>(type: "int", nullable: false),
                    FlightOfferId = table.Column<int>(type: "int", nullable: false),
                    HotelCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PremiumHoliday", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PremiumHoliday_FlightOffers_FlightOfferId",
                        column: x => x.FlightOfferId,
                        principalSchema: "OFFER",
                        principalTable: "FlightOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PremiumHoliday_HolidayOffers_HolidayOfferId",
                        column: x => x.HolidayOfferId,
                        principalSchema: "OFFER",
                        principalTable: "HolidayOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rule",
                schema: "OFFER",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RuleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    HolidayOfferId = table.Column<int>(type: "int", nullable: true),
                    LuxuryHolidayId = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rule_HolidayOffers_HolidayOfferId",
                        column: x => x.HolidayOfferId,
                        principalSchema: "OFFER",
                        principalTable: "HolidayOffers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rule_LuxuryHoliday_LuxuryHolidayId",
                        column: x => x.LuxuryHolidayId,
                        principalSchema: "OFFER",
                        principalTable: "LuxuryHoliday",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LuxuryHoliday_FlightOfferId",
                schema: "OFFER",
                table: "LuxuryHoliday",
                column: "FlightOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_LuxuryHoliday_HolidayOfferId",
                schema: "OFFER",
                table: "LuxuryHoliday",
                column: "HolidayOfferId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PremiumHoliday_FlightOfferId",
                schema: "OFFER",
                table: "PremiumHoliday",
                column: "FlightOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_PremiumHoliday_HolidayOfferId",
                schema: "OFFER",
                table: "PremiumHoliday",
                column: "HolidayOfferId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rule_HolidayOfferId",
                schema: "OFFER",
                table: "Rule",
                column: "HolidayOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Rule_LuxuryHolidayId",
                schema: "OFFER",
                table: "Rule",
                column: "LuxuryHolidayId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offers",
                schema: "OFFER");

            migrationBuilder.DropTable(
                name: "PremiumHoliday",
                schema: "OFFER");

            migrationBuilder.DropTable(
                name: "Rule",
                schema: "OFFER");

            migrationBuilder.DropTable(
                name: "LuxuryHoliday",
                schema: "OFFER");

            migrationBuilder.DropTable(
                name: "FlightOffers",
                schema: "OFFER");

            migrationBuilder.DropTable(
                name: "HolidayOffers",
                schema: "OFFER");
        }
    }
}
