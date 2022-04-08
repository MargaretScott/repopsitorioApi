using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCodeFirst.Migrations
{
    public partial class crear_campo_ciudad_escuelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Schools",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Schools");
        }
    }
}
