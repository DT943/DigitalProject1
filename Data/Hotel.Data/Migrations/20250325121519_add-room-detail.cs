using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Data.Migrations
{
    /// <inheritdoc />
    public partial class addroomdetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageCode",
                schema: "HOTEL",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "ImageUrlPath",
                schema: "HOTEL",
                table: "Rooms");

            migrationBuilder.CreateTable(
                name: "RoomImages",
                schema: "HOTEL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    RoomId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ImageUrlPath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ImageCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Code = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    CreatedBy = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomImages_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalSchema: "HOTEL",
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomImages_RoomId",
                schema: "HOTEL",
                table: "RoomImages",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomImages",
                schema: "HOTEL");

            migrationBuilder.AddColumn<string>(
                name: "ImageCode",
                schema: "HOTEL",
                table: "Rooms",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrlPath",
                schema: "HOTEL",
                table: "Rooms",
                type: "NVARCHAR2(2000)",
                nullable: true);
        }
    }
}
