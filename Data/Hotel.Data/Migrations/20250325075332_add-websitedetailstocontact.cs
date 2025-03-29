using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Data.Migrations
{
    /// <inheritdoc />
    public partial class addwebsitedetailstocontact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Country",
                schema: "HOTEL",
                table: "Hotels",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                schema: "HOTEL",
                table: "ContactInfo",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactType",
                schema: "HOTEL",
                table: "ContactInfo",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsPrimary",
                schema: "HOTEL",
                table: "ContactInfo",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                schema: "HOTEL",
                table: "ContactInfo",
                type: "NVARCHAR2(2000)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                schema: "HOTEL",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "ContactType",
                schema: "HOTEL",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "IsPrimary",
                schema: "HOTEL",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "Url",
                schema: "HOTEL",
                table: "ContactInfo");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                schema: "HOTEL",
                table: "Hotels",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);
        }
    }
}
