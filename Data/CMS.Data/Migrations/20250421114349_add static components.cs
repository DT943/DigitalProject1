using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class addstaticcomponents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StaticComponents",
                schema: "CMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Type = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Content = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Position = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Code = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    CreatedBy = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaticComponents", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StaticComponents",
                schema: "CMS");
        }
    }
}
