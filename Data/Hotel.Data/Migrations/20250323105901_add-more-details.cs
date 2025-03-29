using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Data.Migrations
{
    /// <inheritdoc />
    public partial class addmoredetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                schema: "HOTEL",
                table: "Rooms",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "HOTEL",
                table: "Rooms",
                type: "NVARCHAR2(2000)",
                nullable: true);

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

            migrationBuilder.AddColumn<string>(
                name: "RoomTypeName",
                schema: "HOTEL",
                table: "Rooms",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CommercialDealsFileCode",
                schema: "HOTEL",
                table: "Hotels",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CommercialDealsFileUrlPath",
                schema: "HOTEL",
                table: "Hotels",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                schema: "HOTEL",
                table: "Hotels",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "HOTEL",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "ImageCode",
                schema: "HOTEL",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "ImageUrlPath",
                schema: "HOTEL",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomTypeName",
                schema: "HOTEL",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "CommercialDealsFileCode",
                schema: "HOTEL",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "CommercialDealsFileUrlPath",
                schema: "HOTEL",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Country",
                schema: "HOTEL",
                table: "Hotels");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                schema: "HOTEL",
                table: "Rooms",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);
        }
    }
}
