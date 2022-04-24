using Microsoft.EntityFrameworkCore.Migrations;

namespace WonderlandBooks.Data.Migrations
{
    public partial class RemoveCommentBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Books_BookId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_BookId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Comments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BookId",
                table: "Comments",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Books_BookId",
                table: "Comments",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
