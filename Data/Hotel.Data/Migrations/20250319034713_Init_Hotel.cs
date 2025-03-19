using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init_Hotel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "HOTEL");

            migrationBuilder.CreateTable(
                name: "Hotels",
                schema: "HOTEL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    POS = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Governate = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    StreetAddress = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Rank = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    HasAirConditioning = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    HasBar = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    HasGym = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    HasParking = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    HasPool = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    HasRestaurant = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    HasWifi = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    HasSPA = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    ArePetsAllowed = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    Code = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    CreatedBy = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactInfo",
                schema: "HOTEL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    HotelId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ResponsiblePerson = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Code = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    CreatedBy = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactInfo_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalSchema: "HOTEL",
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelGalleries",
                schema: "HOTEL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    HotelId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    GalleryName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    GalleryCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    GalleryType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Code = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    CreatedBy = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelGalleries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelGalleries_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalSchema: "HOTEL",
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                schema: "HOTEL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    HotelId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Category = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NumberOfAdults = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NumberOfChildren = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Code = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    CreatedBy = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalSchema: "HOTEL",
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfo_HotelId",
                schema: "HOTEL",
                table: "ContactInfo",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelGalleries_HotelId",
                schema: "HOTEL",
                table: "HotelGalleries",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelId",
                schema: "HOTEL",
                table: "Rooms",
                column: "HotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactInfo",
                schema: "HOTEL");

            migrationBuilder.DropTable(
                name: "HotelGalleries",
                schema: "HOTEL");

            migrationBuilder.DropTable(
                name: "Rooms",
                schema: "HOTEL");

            migrationBuilder.DropTable(
                name: "Hotels",
                schema: "HOTEL");
        }
    }
}
