using Microsoft.EntityFrameworkCore.Migrations;

namespace WonderlandBooks.Data.Migrations
{
    public partial class RemovePostBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Books_BookId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_BookId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Posts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_BookId",
                table: "Posts",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Books_BookId",
                table: "Posts",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
