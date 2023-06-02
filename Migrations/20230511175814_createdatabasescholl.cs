using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Scholl.Migrations
{
    /// <inheritdoc />
    public partial class createdatabasescholl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "menu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tela = table.Column<string>(type: "varchar(20)", nullable: false),
                    url = table.Column<string>(type: "varchar(24)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menu", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Aluno",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    data_registro = table.Column<DateTime>(type: "timestamp", nullable: false),
                    sexo = table.Column<int>(type: "int", nullable: false),
                    data_nascimento = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Aluno", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_curso",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "varchar(24)", nullable: false),
                    Data_Cadastro = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_curso", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_departamento",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    nome = table.Column<string>(type: "varchar(24)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_departamento", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_login",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "varchar(24)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(24)", nullable: false),
                    email = table.Column<string>(type: "varchar(150)", nullable: false),
                    n_celular = table.Column<string>(type: "varchar(15)", nullable: false),
                    Data_Registro = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_login", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_perfil",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tipoperfil = table.Column<string>(type: "varchar(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_perfil", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Turma",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "varchar(24)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Turma", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_aluno_presenca",
                columns: table => new
                {
                    id_aluno = table.Column<int>(type: "integer", nullable: false),
                    presenca_falta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_aluno_presenca", x => new { x.id_aluno, x.presenca_falta });
                    table.ForeignKey(
                        name: "FK_tb_aluno_presenca_tb_Aluno_id_aluno",
                        column: x => x.id_aluno,
                        principalTable: "tb_Aluno",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_Professor",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    Data_Registro = table.Column<DateTime>(type: "timestamp", nullable: false),
                    sexo = table.Column<int>(type: "int", nullable: false),
                    Data_Nascimento = table.Column<DateTime>(type: "timestamp", nullable: false),
                    departamento_id = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Professor", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_Professor_tb_departamento_departamento_id",
                        column: x => x.departamento_id,
                        principalTable: "tb_departamento",
                        principalColumn: "id");
                });

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
                        name: "FK_menu_vs_perfil_menu_id_menu",
                        column: x => x.id_menu,
                        principalTable: "menu",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_menu_vs_perfil_tb_perfil_id_perfil",
                        column: x => x.id_perfil,
                        principalTable: "tb_perfil",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "Varchar(24)", nullable: false),
                    id_perfil = table.Column<int>(type: "integer", nullable: false),
                    data_cadastro = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.id);
                    table.ForeignKey(
                        name: "FK_usuario_tb_perfil_id_perfil",
                        column: x => x.id_perfil,
                        principalTable: "tb_perfil",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunoTurma",
                columns: table => new
                {
                    id_aluno = table.Column<int>(type: "integer", nullable: false),
                    id_turma = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoTurma", x => new { x.id_aluno, x.id_turma });
                    table.ForeignKey(
                        name: "FK_AlunoTurma_tb_Aluno_id_aluno",
                        column: x => x.id_aluno,
                        principalTable: "tb_Aluno",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoTurma_tb_Turma_id_turma",
                        column: x => x.id_turma,
                        principalTable: "tb_Turma",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfessorTurma",
                columns: table => new
                {
                    id_professor = table.Column<int>(type: "integer", nullable: false),
                    id_turma = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorTurma", x => new { x.id_professor, x.id_turma });
                    table.ForeignKey(
                        name: "FK_ProfessorTurma_tb_Professor_id_professor",
                        column: x => x.id_professor,
                        principalTable: "tb_Professor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessorTurma_tb_Turma_id_turma",
                        column: x => x.id_turma,
                        principalTable: "tb_Turma",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_avaliacao",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Data_Aplicacao = table.Column<DateTime>(type: "timestamp", nullable: false),
                    descricao = table.Column<string>(type: "varchar(24)", nullable: false),
                    id_professor = table.Column<int>(type: "integer", nullable: false),
                    bimestre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_avaliacao", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_avaliacao_tb_Professor_id_professor",
                        column: x => x.id_professor,
                        principalTable: "tb_Professor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_avaliacao_nota",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_aluno = table.Column<int>(type: "integer", nullable: false),
                    id_avaliacao = table.Column<int>(type: "integer", nullable: false),
                    nota = table.Column<float>(type: "float", nullable: false),
                    data_registro = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_avaliacao_nota", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_avaliacao_nota_tb_Aluno_id_aluno",
                        column: x => x.id_aluno,
                        principalTable: "tb_Aluno",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_avaliacao_nota_tb_avaliacao_id_avaliacao",
                        column: x => x.id_avaliacao,
                        principalTable: "tb_avaliacao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoTurma_id_turma",
                table: "AlunoTurma",
                column: "id_turma");

            migrationBuilder.CreateIndex(
                name: "IX_menu_vs_perfil_id_perfil",
                table: "menu_vs_perfil",
                column: "id_perfil");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorTurma_id_turma",
                table: "ProfessorTurma",
                column: "id_turma");

            migrationBuilder.CreateIndex(
                name: "IX_tb_avaliacao_id_professor",
                table: "tb_avaliacao",
                column: "id_professor");

            migrationBuilder.CreateIndex(
                name: "IX_tb_avaliacao_nota_id_aluno",
                table: "tb_avaliacao_nota",
                column: "id_aluno");

            migrationBuilder.CreateIndex(
                name: "IX_tb_avaliacao_nota_id_avaliacao",
                table: "tb_avaliacao_nota",
                column: "id_avaliacao");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Professor_departamento_id",
                table: "tb_Professor",
                column: "departamento_id");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_id_perfil",
                table: "usuario",
                column: "id_perfil");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoTurma");

            migrationBuilder.DropTable(
                name: "menu_vs_perfil");

            migrationBuilder.DropTable(
                name: "ProfessorTurma");

            migrationBuilder.DropTable(
                name: "tb_aluno_presenca");

            migrationBuilder.DropTable(
                name: "tb_avaliacao_nota");

            migrationBuilder.DropTable(
                name: "tb_curso");

            migrationBuilder.DropTable(
                name: "tb_login");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "menu");

            migrationBuilder.DropTable(
                name: "tb_Turma");

            migrationBuilder.DropTable(
                name: "tb_Aluno");

            migrationBuilder.DropTable(
                name: "tb_avaliacao");

            migrationBuilder.DropTable(
                name: "tb_perfil");

            migrationBuilder.DropTable(
                name: "tb_Professor");

            migrationBuilder.DropTable(
                name: "tb_departamento");
        }
    }
}
