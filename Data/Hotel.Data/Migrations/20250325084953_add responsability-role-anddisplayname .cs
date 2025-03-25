using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Data.Migrations
{
    /// <inheritdoc />
    public partial class addresponsabilityroleanddisplayname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ResponsiblePerson",
                schema: "HOTEL",
                table: "ContactInfo",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                schema: "HOTEL",
                table: "ContactInfo",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "HOTEL",
                table: "ContactInfo",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "DisplayLabel",
                schema: "HOTEL",
                table: "ContactInfo",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResponsiblePersonRole",
                schema: "HOTEL",
                table: "ContactInfo",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayLabel",
                schema: "HOTEL",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "ResponsiblePersonRole",
                schema: "HOTEL",
                table: "ContactInfo");

            migrationBuilder.AlterColumn<string>(
                name: "ResponsiblePerson",
                schema: "HOTEL",
                table: "ContactInfo",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                schema: "HOTEL",
                table: "ContactInfo",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "HOTEL",
                table: "ContactInfo",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
