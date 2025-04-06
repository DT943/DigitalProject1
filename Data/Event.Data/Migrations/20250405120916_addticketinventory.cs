using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event.Data.Migrations
{
    /// <inheritdoc />
    public partial class addticketinventory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TicketInventory",
                schema: "EVENT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TicketNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    UserName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Status = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PaymentTransaction = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TicketIssueDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    TicketId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Code = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    CreatedBy = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketInventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketInventory_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalSchema: "EVENT",
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketInventory_TicketId",
                schema: "EVENT",
                table: "TicketInventory",
                column: "TicketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketInventory",
                schema: "EVENT");
        }
    }
}
