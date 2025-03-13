using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gallery.data.Migrations
{
    /// <inheritdoc />
    public partial class addfilename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Size",
                schema: "GALLERY",
                table: "Files",
                type: "BINARY_FLOAT",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "NUMBER(19)");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
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
                name: "FileName",
                schema: "GALLERY",
                table: "Files");

            migrationBuilder.AlterColumn<long>(
                name: "Size",
                schema: "GALLERY",
                table: "Files",
                type: "NUMBER(19)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "BINARY_FLOAT");
        }
    }
}
