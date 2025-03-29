using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Data.Migrations
{
    /// <inheritdoc />
    public partial class removecodesfromRoomImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                schema: "HOTEL",
                table: "RoomImages");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "HOTEL",
                table: "RoomImages");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "HOTEL",
                table: "RoomImages");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "HOTEL",
                table: "RoomImages");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                schema: "HOTEL",
                table: "RoomImages");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "HOTEL",
                table: "RoomImages",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "HOTEL",
                table: "RoomImages",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "HOTEL",
                table: "RoomImages",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                schema: "HOTEL",
                table: "RoomImages",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                schema: "HOTEL",
                table: "RoomImages",
                type: "TIMESTAMP(7)",
                nullable: true);
        }
    }
}
