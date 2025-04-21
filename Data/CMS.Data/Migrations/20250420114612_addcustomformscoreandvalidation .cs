using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class addcustomformscoreandvalidation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsValid",
                schema: "CMS",
                table: "CustomForms",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Score",
                schema: "CMS",
                table: "CustomForms",
                type: "BINARY_DOUBLE",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsValid",
                schema: "CMS",
                table: "CustomForms");

            migrationBuilder.DropColumn(
                name: "Score",
                schema: "CMS",
                table: "CustomForms");
        }
    }
}
