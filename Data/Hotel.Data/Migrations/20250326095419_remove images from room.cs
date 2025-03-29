using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Data.Migrations
{
    /// <inheritdoc />
    public partial class removeimagesfromroom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomImages",
                schema: "HOTEL");

            migrationBuilder.AddColumn<int>(
                name: "ExtraBedPrice",
                schema: "HOTEL",
                table: "Rooms",
                type: "NUMBER(10)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtraBedPrice",
                schema: "HOTEL",
                table: "Rooms");

            migrationBuilder.CreateTable(
                name: "RoomImages",
                schema: "HOTEL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    RoomId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ImageCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ImageUrlPath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomImages_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalSchema: "HOTEL",
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomImages_RoomId",
                schema: "HOTEL",
                table: "RoomImages",
                column: "RoomId");
        }
    }
}
