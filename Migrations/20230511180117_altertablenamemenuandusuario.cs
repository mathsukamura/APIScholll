using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scholl.Migrations
{
    /// <inheritdoc />
    public partial class altertablenamemenuandusuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_menu_vs_perfil_menu_id_menu",
                table: "menu_vs_perfil");

            migrationBuilder.DropForeignKey(
                name: "FK_usuario_tb_perfil_id_perfil",
                table: "usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usuario",
                table: "usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_menu",
                table: "menu");

            migrationBuilder.RenameTable(
                name: "usuario",
                newName: "tb_usuario");

            migrationBuilder.RenameTable(
                name: "menu",
                newName: "tb_menu");

            migrationBuilder.RenameIndex(
                name: "IX_usuario_id_perfil",
                table: "tb_usuario",
                newName: "IX_tb_usuario_id_perfil");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_usuario",
                table: "tb_usuario",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_menu",
                table: "tb_menu",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_menu_vs_perfil_tb_menu_id_menu",
                table: "menu_vs_perfil",
                column: "id_menu",
                principalTable: "tb_menu",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_usuario_tb_perfil_id_perfil",
                table: "tb_usuario",
                column: "id_perfil",
                principalTable: "tb_perfil",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_menu_vs_perfil_tb_menu_id_menu",
                table: "menu_vs_perfil");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_usuario_tb_perfil_id_perfil",
                table: "tb_usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_usuario",
                table: "tb_usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_menu",
                table: "tb_menu");

            migrationBuilder.RenameTable(
                name: "tb_usuario",
                newName: "usuario");

            migrationBuilder.RenameTable(
                name: "tb_menu",
                newName: "menu");

            migrationBuilder.RenameIndex(
                name: "IX_tb_usuario_id_perfil",
                table: "usuario",
                newName: "IX_usuario_id_perfil");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuario",
                table: "usuario",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_menu",
                table: "menu",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_menu_vs_perfil_menu_id_menu",
                table: "menu_vs_perfil",
                column: "id_menu",
                principalTable: "menu",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_tb_perfil_id_perfil",
                table: "usuario",
                column: "id_perfil",
                principalTable: "tb_perfil",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
