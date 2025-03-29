using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Data.Migrations
{
    /// <inheritdoc />
    public partial class renameShuttle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HasAirportShuttle",
                schema: "HOTEL",
                table: "Hotels",
                newName: "HasShuttle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HasShuttle",
                schema: "HOTEL",
                table: "Hotels",
                newName: "HasAirportShuttle");
        }
    }
}
