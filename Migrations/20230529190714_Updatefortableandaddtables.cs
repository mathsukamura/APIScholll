using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Scholl.Migrations
{
    /// <inheritdoc />
    public partial class Updatefortableandaddtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "menu_vs_perfil");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data_Nascimento",
                table: "tb_usuario",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "e_professor",
                table: "tb_usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "sexo",
                table: "tb_usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id_usuario",
                table: "tb_Professor",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "menu_perfil",
                columns: table => new
                {
                    id_menu = table.Column<int>(type: "integer", nullable: false),
                    id_perfil = table.Column<int>(type: "integer", nullable: false),
                    buscar = table.Column<bool>(type: "boolean", nullable: false),
                    lancar = table.Column<bool>(type: "boolean", nullable: false),
                    alterar = table.Column<bool>(type: "boolean", nullable: false),
                    Deletar = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menu_perfil", x => new { x.id_perfil, x.id_menu });
                    table.ForeignKey(
                        name: "FK_menu_perfil_tb_menu_id_menu",
                        column: x => x.id_menu,
                        principalTable: "tb_menu",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_menu_perfil_tb_perfil_id_perfil",
                        column: x => x.id_perfil,
                        principalTable: "tb_perfil",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuPerfil",
                columns: table => new
                {
                    menus_id = table.Column<int>(type: "integer", nullable: false),
                    perfis_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuPerfil", x => new { x.menus_id, x.perfis_id });
                    table.ForeignKey(
                        name: "FK_MenuPerfil_tb_menu_menus_id",
                        column: x => x.menus_id,
                        principalTable: "tb_menu",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuPerfil_tb_perfil_perfis_id",
                        column: x => x.perfis_id,
                        principalTable: "tb_perfil",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_historico",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    bimestre = table.Column<int>(type: "integer", nullable: false),
                    id_aluno = table.Column<int>(type: "integer", nullable: false),
                    notafinal1 = table.Column<float>(type: "float", nullable: false),
                    notafinal2 = table.Column<float>(type: "float", nullable: false),
                    notafinal3 = table.Column<float>(type: "float", nullable: false),
                    notafinal4 = table.Column<float>(type: "float", nullable: false),
                    dataregistro = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_historico", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_historico_tb_Aluno_id_aluno",
                        column: x => x.id_aluno,
                        principalTable: "tb_Aluno",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_Professor_id_usuario",
                table: "tb_Professor",
                column: "id_usuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_menu_perfil_id_menu",
                table: "menu_perfil",
                column: "id_menu");

            migrationBuilder.CreateIndex(
                name: "IX_MenuPerfil_perfis_id",
                table: "MenuPerfil",
                column: "perfis_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_historico_id_aluno",
                table: "tb_historico",
                column: "id_aluno",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_Professor_tb_usuario_id_usuario",
                table: "tb_Professor",
                column: "id_usuario",
                principalTable: "tb_usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_Professor_tb_usuario_id_usuario",
                table: "tb_Professor");

            migrationBuilder.DropTable(
                name: "menu_perfil");

            migrationBuilder.DropTable(
                name: "MenuPerfil");

            migrationBuilder.DropTable(
                name: "tb_historico");

            migrationBuilder.DropIndex(
                name: "IX_tb_Professor_id_usuario",
                table: "tb_Professor");

            migrationBuilder.DropColumn(
                name: "Data_Nascimento",
                table: "tb_usuario");

            migrationBuilder.DropColumn(
                name: "e_professor",
                table: "tb_usuario");

            migrationBuilder.DropColumn(
                name: "sexo",
                table: "tb_usuario");

            migrationBuilder.DropColumn(
                name: "id_usuario",
                table: "tb_Professor");

            migrationBuilder.CreateTable(
                name: "menu_vs_perfil",
                columns: table => new
                {
                    id_menu = table.Column<int>(type: "integer", nullable: false),
                    id_perfil = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menu_vs_perfil", x => new { x.id_menu, x.id_perfil });
                    table.ForeignKey(
                        name: "FK_menu_vs_perfil_tb_menu_id_menu",
                        column: x => x.id_menu,
                        principalTable: "tb_menu",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_menu_vs_perfil_tb_perfil_id_perfil",
                        column: x => x.id_perfil,
                        principalTable: "tb_perfil",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_menu_vs_perfil_id_perfil",
                table: "menu_vs_perfil",
                column: "id_perfil");
        }
    }
}
