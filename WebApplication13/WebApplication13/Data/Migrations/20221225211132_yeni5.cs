using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication13.Data.Migrations
{
    public partial class yeni5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Carts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
