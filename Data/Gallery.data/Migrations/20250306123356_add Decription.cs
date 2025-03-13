using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gallery.data.Migrations
{
    /// <inheritdoc />
    public partial class addDecription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "GALLERY",
                table: "Files",
                type: "NVARCHAR2(2000)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "GALLERY",
                table: "Files");
        }
    }
}
