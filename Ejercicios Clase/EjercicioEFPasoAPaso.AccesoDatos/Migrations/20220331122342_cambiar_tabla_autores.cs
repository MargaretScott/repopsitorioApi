using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EjercicioEFPasoAPaso.AccesoDatos.Migrations
{
    public partial class cambiar_tabla_autores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Autor_AutorId",
                table: "Libros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Autor",
                table: "Autor");

            migrationBuilder.RenameTable(
                name: "Autor",
                newName: "Autores");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Autores",
                table: "Autores",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Autores_AutorId",
                table: "Libros",
                column: "AutorId",
                principalTable: "Autores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Autores_AutorId",
                table: "Libros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Autores",
                table: "Autores");

            migrationBuilder.RenameTable(
                name: "Autores",
                newName: "Autor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Autor",
                table: "Autor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Autor_AutorId",
                table: "Libros",
                column: "AutorId",
                principalTable: "Autor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
