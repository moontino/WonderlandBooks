namespace WonderlandBooks.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class DeleteTableBookSeries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookSeries_BookSeriesId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "BookSeries");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookSeriesId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookSeriesId",
                table: "Books");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookSeriesId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BookSeries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookSeries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookSeries_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookSeriesId",
                table: "Books",
                column: "BookSeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_BookSeries_AuthorId",
                table: "BookSeries",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookSeries_Name",
                table: "BookSeries",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookSeries_BookSeriesId",
                table: "Books",
                column: "BookSeriesId",
                principalTable: "BookSeries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
