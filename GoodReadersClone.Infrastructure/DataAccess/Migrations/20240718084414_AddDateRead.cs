﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoodReadsClone.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDateRead : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateRead",
                table: "ShelfItems",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateRead",
                table: "ShelfItems");
        }
    }
}
