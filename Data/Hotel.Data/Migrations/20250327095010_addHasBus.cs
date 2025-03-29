using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Data.Migrations
{
    /// <inheritdoc />
    public partial class addHasBus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommercialDealsFileCode",
                schema: "HOTEL",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "CommercialDealsFileUrlPath",
                schema: "HOTEL",
                table: "Hotels");

            migrationBuilder.AddColumn<bool>(
                name: "HasAirportShuttle",
                schema: "HOTEL",
                table: "Hotels",
                type: "NUMBER(1)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasAirportShuttle",
                schema: "HOTEL",
                table: "Hotels");

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
        }
    }
}
