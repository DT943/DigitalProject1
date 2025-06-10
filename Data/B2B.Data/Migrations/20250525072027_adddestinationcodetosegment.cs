using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2B.Data.Migrations
{
    /// <inheritdoc />
    public partial class adddestinationcodetosegment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DestinationCode",
                table: "Segments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DestinationName",
                table: "Segments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DestinationCode",
                table: "Segments");

            migrationBuilder.DropColumn(
                name: "DestinationName",
                table: "Segments");
        }
    }
}
