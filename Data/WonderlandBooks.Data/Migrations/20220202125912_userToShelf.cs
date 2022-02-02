using Microsoft.EntityFrameworkCore.Migrations;

namespace WonderlandBooks.Data.Migrations
{
    public partial class userToShelf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shelf_AspNetUsers_ApplicationUserId",
                table: "Shelf");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Shelf",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Shelf_ApplicationUserId",
                table: "Shelf",
                newName: "IX_Shelf_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "StoryId",
                table: "Chapters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Shelf_AspNetUsers_UserId",
                table: "Shelf",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shelf_AspNetUsers_UserId",
                table: "Shelf");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Shelf",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Shelf_UserId",
                table: "Shelf",
                newName: "IX_Shelf_ApplicationUserId");

            migrationBuilder.AlterColumn<int>(
                name: "StoryId",
                table: "Chapters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Shelf_AspNetUsers_ApplicationUserId",
                table: "Shelf",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
