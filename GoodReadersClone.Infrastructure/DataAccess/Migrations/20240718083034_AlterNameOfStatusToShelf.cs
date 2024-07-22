using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoodReadsClone.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterNameOfStatusToShelf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "ShelfItems",
                newName: "Shelf");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Shelf",
                table: "ShelfItems",
                newName: "Status");
        }
    }
}
