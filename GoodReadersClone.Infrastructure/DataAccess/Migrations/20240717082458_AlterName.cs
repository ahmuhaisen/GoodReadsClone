using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoodReadersClone.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorFollowing_Users_ApplicationUserId",
                table: "AuthorFollowing");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorFollowing_Users_AuthorId",
                table: "AuthorFollowing");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorFollowing",
                table: "AuthorFollowing");

            migrationBuilder.RenameTable(
                name: "AuthorFollowing",
                newName: "AuthorFollowings");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorFollowing_AuthorId",
                table: "AuthorFollowings",
                newName: "IX_AuthorFollowings_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorFollowings",
                table: "AuthorFollowings",
                columns: new[] { "ApplicationUserId", "AuthorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorFollowings_Users_ApplicationUserId",
                table: "AuthorFollowings",
                column: "ApplicationUserId",
                principalSchema: "security",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorFollowings_Users_AuthorId",
                table: "AuthorFollowings",
                column: "AuthorId",
                principalSchema: "security",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorFollowings_Users_ApplicationUserId",
                table: "AuthorFollowings");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorFollowings_Users_AuthorId",
                table: "AuthorFollowings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorFollowings",
                table: "AuthorFollowings");

            migrationBuilder.RenameTable(
                name: "AuthorFollowings",
                newName: "AuthorFollowing");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorFollowings_AuthorId",
                table: "AuthorFollowing",
                newName: "IX_AuthorFollowing_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorFollowing",
                table: "AuthorFollowing",
                columns: new[] { "ApplicationUserId", "AuthorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorFollowing_Users_ApplicationUserId",
                table: "AuthorFollowing",
                column: "ApplicationUserId",
                principalSchema: "security",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorFollowing_Users_AuthorId",
                table: "AuthorFollowing",
                column: "AuthorId",
                principalSchema: "security",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
