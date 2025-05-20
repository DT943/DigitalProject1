using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2B.Data.Migrations
{
    /// <inheritdoc />
    public partial class reservationreport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PNR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumAdt = table.Column<int>(type: "int", nullable: true),
                    NumChd = table.Column<int>(type: "int", nullable: true),
                    NumInf = table.Column<int>(type: "int", nullable: true),
                    POS = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FlightClass = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OriginCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OriginName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DestinationCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DestinationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DepartureDate = table.Column<DateOnly>(type: "date", nullable: false),
                    DepartureTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    ArrivalDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ArrivalTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    TotalFare = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AirArabia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PNR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirArabia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AirArabia_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactInfo_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    given_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passengers_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Segments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OriginName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DepartureDate = table.Column<DateOnly>(type: "date", nullable: false),
                    DepartureTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    ArrivalDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ArrivalTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    FlightNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReservationiD = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Segments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Segments_Reservations_ReservationiD",
                        column: x => x.ReservationiD,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AirArabia_ReservationId",
                table: "AirArabia",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfo_ReservationId",
                table: "ContactInfo",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_ReservationId",
                table: "Passengers",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Segments_ReservationiD",
                table: "Segments",
                column: "ReservationiD");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirArabia");

            migrationBuilder.DropTable(
                name: "ContactInfo");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "Segments");

            migrationBuilder.DropTable(
                name: "Reservations");
        }
    }
}
