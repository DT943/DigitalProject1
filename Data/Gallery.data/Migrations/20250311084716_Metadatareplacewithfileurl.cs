using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gallery.data.Migrations
{
    /// <inheritdoc />
    public partial class Metadatareplacewithfileurl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Metadata",
                schema: "GALLERY",
                table: "Files");

            migrationBuilder.AddColumn<string>(
                name: "FileUrlPath",
                schema: "GALLERY",
                table: "Files",
                type: "NVARCHAR2(2000)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileUrlPath",
                schema: "GALLERY",
                table: "Files");

            migrationBuilder.AddColumn<string>(
                name: "Metadata",
                schema: "GALLERY",
                table: "Files",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");
        }
    }
}
