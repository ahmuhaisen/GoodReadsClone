using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoodReadersClone.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddShelfItemsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShelfItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    ReaderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShelfItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShelfItems_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShelfItems_Users_ReaderId",
                        column: x => x.ReaderId,
                        principalSchema: "security",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShelfItems_BookId",
                table: "ShelfItems",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_ShelfItems_ReaderId",
                table: "ShelfItems",
                column: "ReaderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShelfItems");
        }
    }
}
