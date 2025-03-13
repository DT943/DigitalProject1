using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gallery.data.Migrations
{
    /// <inheritdoc />
    public partial class addAlternativeTextandDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AlternativeText",
                schema: "GALLERY",
                table: "Files",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Caption",
                schema: "GALLERY",
                table: "Files",
                type: "NVARCHAR2(2000)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlternativeText",
                schema: "GALLERY",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Caption",
                schema: "GALLERY",
                table: "Files");
        }
    }
}
