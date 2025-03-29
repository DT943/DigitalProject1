using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Data.Migrations
{
    /// <inheritdoc />
    public partial class addpriceonhotel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtraBedPrice",
                schema: "HOTEL",
                table: "Rooms");

            migrationBuilder.AddColumn<int>(
                name: "ExtraBedPrice",
                schema: "HOTEL",
                table: "Hotels",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasBreakfast",
                schema: "HOTEL",
                table: "Hotels",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasExtraBed",
                schema: "HOTEL",
                table: "Hotels",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtraBedPrice",
                schema: "HOTEL",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "HasBreakfast",
                schema: "HOTEL",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "HasExtraBed",
                schema: "HOTEL",
                table: "Hotels");

            migrationBuilder.AddColumn<int>(
                name: "ExtraBedPrice",
                schema: "HOTEL",
                table: "Rooms",
                type: "NUMBER(10)",
                nullable: true);
        }
    }
}
