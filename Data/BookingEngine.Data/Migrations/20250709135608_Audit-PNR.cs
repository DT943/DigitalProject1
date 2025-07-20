using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingEngine.Data.Migrations
{
    /// <inheritdoc />
    public partial class AuditPNR : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookContactInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreferredLanguage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookContactInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookFares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseFare = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalFareUSD = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalFareSYP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalFareWithCCFeeUSD = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalFareWithCCFeeSYP = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookFares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookPassengerCounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adults = table.Column<int>(type: "int", nullable: false),
                    Children = table.Column<int>(type: "int", nullable: false),
                    Infants = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookPassengerCounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookFees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DecimalPlaces = table.Column<int>(type: "int", nullable: false),
                    FeeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookFareId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookFees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookFees_BookFares_BookFareId",
                        column: x => x.BookFareId,
                        principalTable: "BookFares",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BookTaxs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DecimalPlaces = table.Column<int>(type: "int", nullable: false),
                    TaxCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookFareId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTaxs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookTaxs_BookFares_BookFareId",
                        column: x => x.BookFareId,
                        principalTable: "BookFares",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InquirePNRResponse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Errors = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingReference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketTimeLimit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TicketAdvisory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FareId = table.Column<int>(type: "int", nullable: false),
                    ContactInfoId = table.Column<int>(type: "int", nullable: false),
                    PassengerCountsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InquirePNRResponse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InquirePNRResponse_BookContactInfos_ContactInfoId",
                        column: x => x.ContactInfoId,
                        principalTable: "BookContactInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InquirePNRResponse_BookFares_FareId",
                        column: x => x.FareId,
                        principalTable: "BookFares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InquirePNRResponse_BookPassengerCounts_PassengerCountsId",
                        column: x => x.PassengerCountsId,
                        principalTable: "BookPassengerCounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookFlightSegments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlightNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureAirport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArrivalAirport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureTerminal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CabinClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rph = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InquirePNRResponseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookFlightSegments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookFlightSegments_InquirePNRResponse_InquirePNRResponseId",
                        column: x => x.InquirePNRResponseId,
                        principalTable: "InquirePNRResponse",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BookPassengers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassengerType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentIssueCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentExpiry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rph = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InquirePNRResponseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookPassengers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookPassengers_InquirePNRResponse_InquirePNRResponseId",
                        column: x => x.InquirePNRResponseId,
                        principalTable: "InquirePNRResponse",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InquirePNRs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PNR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InquirePNRResponseId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InquirePNRs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InquirePNRs_InquirePNRResponse_InquirePNRResponseId",
                        column: x => x.InquirePNRResponseId,
                        principalTable: "InquirePNRResponse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookETickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CouponNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ETicketNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlightSegmentCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlightSegmentRPH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsedStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookPassengerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookETickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookETickets_BookPassengers_BookPassengerId",
                        column: x => x.BookPassengerId,
                        principalTable: "BookPassengers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookETickets_BookPassengerId",
                table: "BookETickets",
                column: "BookPassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_BookFees_BookFareId",
                table: "BookFees",
                column: "BookFareId");

            migrationBuilder.CreateIndex(
                name: "IX_BookFlightSegments_InquirePNRResponseId",
                table: "BookFlightSegments",
                column: "InquirePNRResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_BookPassengers_InquirePNRResponseId",
                table: "BookPassengers",
                column: "InquirePNRResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_BookTaxs_BookFareId",
                table: "BookTaxs",
                column: "BookFareId");

            migrationBuilder.CreateIndex(
                name: "IX_InquirePNRResponse_ContactInfoId",
                table: "InquirePNRResponse",
                column: "ContactInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_InquirePNRResponse_FareId",
                table: "InquirePNRResponse",
                column: "FareId");

            migrationBuilder.CreateIndex(
                name: "IX_InquirePNRResponse_PassengerCountsId",
                table: "InquirePNRResponse",
                column: "PassengerCountsId");

            migrationBuilder.CreateIndex(
                name: "IX_InquirePNRs_InquirePNRResponseId",
                table: "InquirePNRs",
                column: "InquirePNRResponseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookETickets");

            migrationBuilder.DropTable(
                name: "BookFees");

            migrationBuilder.DropTable(
                name: "BookFlightSegments");

            migrationBuilder.DropTable(
                name: "BookTaxs");

            migrationBuilder.DropTable(
                name: "InquirePNRs");

            migrationBuilder.DropTable(
                name: "BookPassengers");

            migrationBuilder.DropTable(
                name: "InquirePNRResponse");

            migrationBuilder.DropTable(
                name: "BookContactInfos");

            migrationBuilder.DropTable(
                name: "BookFares");

            migrationBuilder.DropTable(
                name: "BookPassengerCounts");
        }
    }
}
