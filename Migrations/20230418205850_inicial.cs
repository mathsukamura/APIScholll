using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Scholl.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_Aluno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    data_registro = table.Column<DateTime>(type: "timestamp", nullable: false),
                    sexo = table.Column<int>(type: "int", nullable: false),
                    data_nascimento = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Aluno", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_curso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "varchar(24)", nullable: false),
                    Data_Cadastro = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_curso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_departamento",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    nome = table.Column<string>(type: "varchar(24)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_departamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_login",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "varchar(24)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(24)", nullable: false),
                    Email = table.Column<string>(type: "varchar(150)", nullable: false),
                    n_celular = table.Column<string>(type: "varchar(15)", nullable: false),
                    Data_Registro = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_login", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Turma",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "varchar(24)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Turma", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Professor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    Data_Registro = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Sexo = table.Column<int>(type: "int", nullable: false),
                    Data_Nascimento = table.Column<DateTime>(type: "timestamp", nullable: false),
                    DepartamentoId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Professor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_Professor_tb_departamento_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "tb_departamento",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AlunoTurma",
                columns: table => new
                {
                    IdAluno = table.Column<int>(type: "integer", nullable: false),
                    IdTurma = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoTurma", x => new { x.IdAluno, x.IdTurma });
                    table.ForeignKey(
                        name: "FK_AlunoTurma_tb_Aluno_IdAluno",
                        column: x => x.IdAluno,
                        principalTable: "tb_Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoTurma_tb_Turma_IdTurma",
                        column: x => x.IdTurma,
                        principalTable: "tb_Turma",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfessorTurma",
                columns: table => new
                {
                    IdProfessor = table.Column<int>(type: "integer", nullable: false),
                    IdTurma = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorTurma", x => new { x.IdProfessor, x.IdTurma });
                    table.ForeignKey(
                        name: "FK_ProfessorTurma_tb_Professor_IdProfessor",
                        column: x => x.IdProfessor,
                        principalTable: "tb_Professor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessorTurma_tb_Turma_IdTurma",
                        column: x => x.IdTurma,
                        principalTable: "tb_Turma",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_avaliacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataAplicacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    descricao = table.Column<string>(type: "varchar(24)", nullable: false),
                    IdProfessor = table.Column<int>(type: "integer", nullable: false),
                    Bimestre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_avaliacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_avaliacao_tb_Professor_IdProfessor",
                        column: x => x.IdProfessor,
                        principalTable: "tb_Professor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_avaliacao_nota",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdAluno = table.Column<int>(type: "integer", nullable: false),
                    IdAvaliacao = table.Column<int>(type: "integer", nullable: false),
                    nota = table.Column<float>(type: "float", nullable: false),
                    data_registro = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_avaliacao_nota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_avaliacao_nota_tb_Aluno_IdAluno",
                        column: x => x.IdAluno,
                        principalTable: "tb_Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_avaliacao_nota_tb_avaliacao_IdAvaliacao",
                        column: x => x.IdAvaliacao,
                        principalTable: "tb_avaliacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoTurma_IdTurma",
                table: "AlunoTurma",
                column: "IdTurma");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorTurma_IdTurma",
                table: "ProfessorTurma",
                column: "IdTurma");

            migrationBuilder.CreateIndex(
                name: "IX_tb_avaliacao_IdProfessor",
                table: "tb_avaliacao",
                column: "IdProfessor");

            migrationBuilder.CreateIndex(
                name: "IX_tb_avaliacao_nota_IdAluno",
                table: "tb_avaliacao_nota",
                column: "IdAluno");

            migrationBuilder.CreateIndex(
                name: "IX_tb_avaliacao_nota_IdAvaliacao",
                table: "tb_avaliacao_nota",
                column: "IdAvaliacao");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Professor_DepartamentoId",
                table: "tb_Professor",
                column: "DepartamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoTurma");

            migrationBuilder.DropTable(
                name: "ProfessorTurma");

            migrationBuilder.DropTable(
                name: "tb_avaliacao_nota");

            migrationBuilder.DropTable(
                name: "tb_curso");

            migrationBuilder.DropTable(
                name: "tb_login");

            migrationBuilder.DropTable(
                name: "tb_Turma");

            migrationBuilder.DropTable(
                name: "tb_Aluno");

            migrationBuilder.DropTable(
                name: "tb_avaliacao");

            migrationBuilder.DropTable(
                name: "tb_Professor");

            migrationBuilder.DropTable(
                name: "tb_departamento");
        }
    }
}
