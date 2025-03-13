using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gallery.data.Migrations
{
    /// <inheritdoc />
    public partial class addbase64 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Base64Content",
                schema: "GALLERY",
                table: "Files",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Base64Content",
                schema: "GALLERY",
                table: "Files");
        }
    }
}
