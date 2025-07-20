using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingEngine.Data.Migrations
{
    /// <inheritdoc />
    public partial class pnrpayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentPNRContact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryIsoCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreferredLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentPNRContact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentPNRResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketAdvisory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PNR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseFareAmount = table.Column<float>(type: "real", nullable: true),
                    BaseFareCurrency = table.Column<float>(type: "real", nullable: true),
                    TotalFareAmount = table.Column<float>(type: "real", nullable: true),
                    TotalFareCurrency = table.Column<float>(type: "real", nullable: true),
                    TotalEquivFareAmount = table.Column<float>(type: "real", nullable: true),
                    TotalEquivFareCurrency = table.Column<float>(type: "real", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentAmount = table.Column<float>(type: "real", nullable: true),
                    PaymentCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentAmountInPayCurAmount = table.Column<float>(type: "real", nullable: true),
                    PaymentAmountInPayCurCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TicketingStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TicketType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfADT = table.Column<int>(type: "int", nullable: true),
                    NumberOfCHD = table.Column<int>(type: "int", nullable: true),
                    NumberOfINF = table.Column<int>(type: "int", nullable: true),
                    ContactId = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentPNRResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentPNRResults_PaymentPNRContact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "PaymentPNRContact",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PaymentPNRETicketInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ETicketNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CouponNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlightSegmentRPH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TicketStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsedStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentPNRResultId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentPNRETicketInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentPNRETicketInfo_PaymentPNRResults_PaymentPNRResultId",
                        column: x => x.PaymentPNRResultId,
                        principalTable: "PaymentPNRResults",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PaymentPNRFee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<float>(type: "real", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentPNRResultId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentPNRFee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentPNRFee_PaymentPNRResults_PaymentPNRResultId",
                        column: x => x.PaymentPNRResultId,
                        principalTable: "PaymentPNRResults",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PaymentPNRFlightSegment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartureAirportCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArrivalAirportCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartureDateTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArrivalDateTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Terminal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CabinClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RPH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentPNRResultId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentPNRFlightSegment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentPNRFlightSegment_PaymentPNRResults_PaymentPNRResultId",
                        column: x => x.PaymentPNRResultId,
                        principalTable: "PaymentPNRResults",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PaymentPNRPassenger",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentPNRResultId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentPNRPassenger", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentPNRPassenger_PaymentPNRResults_PaymentPNRResultId",
                        column: x => x.PaymentPNRResultId,
                        principalTable: "PaymentPNRResults",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PaymentPNRTax",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<float>(type: "real", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentPNRResultId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentPNRTax", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentPNRTax_PaymentPNRResults_PaymentPNRResultId",
                        column: x => x.PaymentPNRResultId,
                        principalTable: "PaymentPNRResults",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentPNRETicketInfo_PaymentPNRResultId",
                table: "PaymentPNRETicketInfo",
                column: "PaymentPNRResultId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentPNRFee_PaymentPNRResultId",
                table: "PaymentPNRFee",
                column: "PaymentPNRResultId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentPNRFlightSegment_PaymentPNRResultId",
                table: "PaymentPNRFlightSegment",
                column: "PaymentPNRResultId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentPNRPassenger_PaymentPNRResultId",
                table: "PaymentPNRPassenger",
                column: "PaymentPNRResultId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentPNRResults_ContactId",
                table: "PaymentPNRResults",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentPNRTax_PaymentPNRResultId",
                table: "PaymentPNRTax",
                column: "PaymentPNRResultId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentPNRETicketInfo");

            migrationBuilder.DropTable(
                name: "PaymentPNRFee");

            migrationBuilder.DropTable(
                name: "PaymentPNRFlightSegment");

            migrationBuilder.DropTable(
                name: "PaymentPNRPassenger");

            migrationBuilder.DropTable(
                name: "PaymentPNRTax");

            migrationBuilder.DropTable(
                name: "PaymentPNRResults");

            migrationBuilder.DropTable(
                name: "PaymentPNRContact");
        }
    }
}
