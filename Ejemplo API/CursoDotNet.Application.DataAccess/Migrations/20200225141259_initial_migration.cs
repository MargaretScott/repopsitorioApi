using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CursoDotNet.DataAccess.Migrations
{
    public partial class initial_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    createUserId = table.Column<int>(nullable: false),
                    createDateTime = table.Column<DateTime>(nullable: false),
                    updateUserId = table.Column<int>(nullable: true),
                    updateDateTime = table.Column<DateTime>(nullable: true),
                    description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    createUserId = table.Column<int>(nullable: false),
                    createDateTime = table.Column<DateTime>(nullable: false),
                    updateUserId = table.Column<int>(nullable: true),
                    updateDateTime = table.Column<DateTime>(nullable: true),
                    name = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: false),
                    roleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_roleId",
                        column: x => x.roleId,
                        principalTable: "Roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    createUserId = table.Column<int>(nullable: false),
                    createDateTime = table.Column<DateTime>(nullable: false),
                    updateUserId = table.Column<int>(nullable: true),
                    updateDateTime = table.Column<DateTime>(nullable: true),
                    brand = table.Column<string>(nullable: false),
                    model = table.Column<string>(nullable: false),
                    Version = table.Column<string>(nullable: true),
                    Userid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.id);
                    table.ForeignKey(
                        name: "FK_Cars_Users_Userid",
                        column: x => x.Userid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_Userid",
                table: "Cars",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_Users_roleId",
                table: "Users",
                column: "roleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
