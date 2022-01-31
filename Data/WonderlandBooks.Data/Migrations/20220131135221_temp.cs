using Microsoft.EntityFrameworkCore.Migrations;

namespace WonderlandBooks.Data.Migrations
{
    public partial class temp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfSet",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "CreativeWritingId",
                table: "Stories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CreativeWritingId",
                table: "Stories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfSet",
                table: "Books",
                type: "int",
                nullable: true);
        }
    }
}
