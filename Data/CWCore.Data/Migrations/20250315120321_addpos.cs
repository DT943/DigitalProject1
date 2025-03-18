using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CWCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class addpos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CWCORE");

            migrationBuilder.CreateTable(
                name: "POSs",
                schema: "CWCORE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Key = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ArabicName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    EnglishName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Code = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    CreatedBy = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POSs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "POSs",
                schema: "CWCORE");
        }
    }
}
