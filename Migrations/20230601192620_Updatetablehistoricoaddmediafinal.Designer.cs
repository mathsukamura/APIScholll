﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Scholl.Data;

#nullable disable

namespace Scholl.Migrations
{
    [DbContext(typeof(AppDbcontext))]
    [Migration("20230601192620_Updatetablehistoricoaddmediafinal")]
    partial class Updatetablehistoricoaddmediafinal
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MenuPerfil", b =>
                {
                    b.Property<int>("MenusId")
                        .HasColumnType("integer")
                        .HasColumnName("menus_id");

                    b.Property<int>("PerfisId")
                        .HasColumnType("integer")
                        .HasColumnName("perfis_id");

                    b.HasKey("MenusId", "PerfisId");

                    b.HasIndex("PerfisId");

                    b.ToTable("MenuPerfil");
                });

            modelBuilder.Entity("Scholl.AlunoModel.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("timestamp")
                        .HasColumnName("data_nascimento");

                    b.Property<DateTime>("DataRegistro")
                        .HasColumnType("timestamp")
                        .HasColumnName("data_registro");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("nome");

                    b.Property<int>("Sexo")
                        .HasColumnType("int")
                        .HasColumnName("sexo");

                    b.HasKey("Id");

                    b.ToTable("tb_Aluno", (string)null);
                });

            modelBuilder.Entity("Scholl.AlunoTurmamodel.AlunoTurma", b =>
                {
                    b.Property<int>("IdAluno")
                        .HasColumnType("integer")
                        .HasColumnName("id_aluno");

                    b.Property<int>("IdTurma")
                        .HasColumnType("integer")
                        .HasColumnName("id_turma");

                    b.HasKey("IdAluno", "IdTurma");

                    b.HasIndex("IdTurma");

                    b.ToTable("AlunoTurma");
                });

            modelBuilder.Entity("Scholl.AvaliacaoModel.Avaliacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Bimestre")
                        .HasColumnType("int")
                        .HasColumnName("bimestre");

                    b.Property<DateTime>("DataAplicacao")
                        .HasColumnType("timestamp")
                        .HasColumnName("Data_Aplicacao");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(24)")
                        .HasColumnName("descricao");

                    b.Property<int>("IdProfessor")
                        .HasColumnType("integer")
                        .HasColumnName("id_professor");

                    b.HasKey("Id");

                    b.HasIndex("IdProfessor");

                    b.ToTable("tb_avaliacao", (string)null);
                });

            modelBuilder.Entity("Scholl.AvaliacaoModel.AvaliacaoNota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataRealizacao")
                        .HasColumnType("timestamp")
                        .HasColumnName("data_registro");

                    b.Property<int>("IdAluno")
                        .HasColumnType("integer")
                        .HasColumnName("id_aluno");

                    b.Property<int>("IdAvaliacao")
                        .HasColumnType("integer")
                        .HasColumnName("id_avaliacao");

                    b.Property<double>("Nota")
                        .HasColumnType("double precision")
                        .HasColumnName("nota");

                    b.HasKey("Id");

                    b.HasIndex("IdAluno");

                    b.HasIndex("IdAvaliacao");

                    b.ToTable("tb_avaliacao_nota", (string)null);
                });

            modelBuilder.Entity("Scholl.CursoModel.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("timestamp")
                        .HasColumnName("Data_Cadastro");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(24)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("tb_curso", (string)null);
                });

            modelBuilder.Entity("Scholl.DepartamentoModel.Departamento", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(24)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("tb_departamento", (string)null);
                });

            modelBuilder.Entity("Scholl.HistoricoModel.Historico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Bimestre")
                        .HasColumnType("integer")
                        .HasColumnName("bimestre");

                    b.Property<DateTime>("DataRegistro")
                        .HasColumnType("timestamp")
                        .HasColumnName("dataregistro");

                    b.Property<int>("IdAluno")
                        .HasColumnType("integer")
                        .HasColumnName("id_aluno");

                    b.Property<double>("MediaFinal")
                        .HasColumnType("double precision")
                        .HasColumnName("mediafinal");

                    b.Property<double>("NotaFinal1")
                        .HasColumnType("double precision")
                        .HasColumnName("notafinal1");

                    b.Property<double>("NotaFinal2")
                        .HasColumnType("double precision")
                        .HasColumnName("notafinal2");

                    b.Property<double>("NotaFinal3")
                        .HasColumnType("double precision")
                        .HasColumnName("notafinal3");

                    b.Property<double>("NotaFinal4")
                        .HasColumnType("double precision")
                        .HasColumnName("notafinal4");

                    b.HasKey("Id");

                    b.HasIndex("IdAluno");

                    b.ToTable("tb_historico", (string)null);
                });

            modelBuilder.Entity("Scholl.Models.AlunoPresenca", b =>
                {
                    b.Property<int>("IdAluno")
                        .HasColumnType("integer")
                        .HasColumnName("id_aluno");

                    b.Property<int>("presencafalta")
                        .HasColumnType("int")
                        .HasColumnName("presenca_falta");

                    b.HasKey("IdAluno", "presencafalta");

                    b.ToTable("tb_aluno_presenca", (string)null);
                });

            modelBuilder.Entity("Scholl.Models.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Tela")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("tela");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("varchar(24)")
                        .HasColumnName("url");

                    b.HasKey("Id");

                    b.ToTable("tb_menu", (string)null);
                });

            modelBuilder.Entity("Scholl.Models.Perfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("TipoPerfil")
                        .IsRequired()
                        .HasColumnType("varchar(15)")
                        .HasColumnName("tipoperfil");

                    b.HasKey("Id");

                    b.ToTable("tb_perfil", (string)null);
                });

            modelBuilder.Entity("Scholl.Models.PerfilMenu", b =>
                {
                    b.Property<int>("IdPerfil")
                        .HasColumnType("integer")
                        .HasColumnName("id_perfil");

                    b.Property<int>("IdMenu")
                        .HasColumnType("integer")
                        .HasColumnName("id_menu");

                    b.Property<bool>("Delete")
                        .HasColumnType("boolean")
                        .HasColumnName("Deletar");

                    b.Property<bool>("Get")
                        .HasColumnType("boolean")
                        .HasColumnName("buscar");

                    b.Property<bool>("Post")
                        .HasColumnType("boolean")
                        .HasColumnName("lancar");

                    b.Property<bool>("Put")
                        .HasColumnType("boolean")
                        .HasColumnName("alterar");

                    b.HasKey("IdPerfil", "IdMenu");

                    b.HasIndex("IdMenu");

                    b.ToTable("menu_perfil", (string)null);
                });

            modelBuilder.Entity("Scholl.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("timestamp")
                        .HasColumnName("data_cadastro");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("timestamp")
                        .HasColumnName("Data_Nascimento");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("Varchar(64)")
                        .HasColumnName("email");

                    b.Property<int>("Eprofessor")
                        .HasColumnType("int")
                        .HasColumnName("e_professor");

                    b.Property<int>("IdPerfil")
                        .HasColumnType("integer")
                        .HasColumnName("id_perfil");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("Varchar(24)")
                        .HasColumnName("name");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("Varchar(24)")
                        .HasColumnName("senha");

                    b.Property<int>("Sexo")
                        .HasColumnType("int")
                        .HasColumnName("sexo");

                    b.HasKey("Id");

                    b.HasIndex("IdPerfil");

                    b.ToTable("tb_usuario", (string)null);
                });

            modelBuilder.Entity("Scholl.ProfessorModel.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("timestamp")
                        .HasColumnName("Data_Nascimento");

                    b.Property<DateTime>("DataRegistro")
                        .HasColumnType("timestamp")
                        .HasColumnName("Data_Registro");

                    b.Property<string>("DepartamentoId")
                        .HasColumnType("text")
                        .HasColumnName("departamento_id");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("integer")
                        .HasColumnName("id_usuario");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("nome");

                    b.Property<int>("Sexo")
                        .HasColumnType("int")
                        .HasColumnName("sexo");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.HasIndex("IdUsuario")
                        .IsUnique();

                    b.ToTable("tb_Professor", (string)null);
                });

            modelBuilder.Entity("Scholl.ProfessorTurmamodel.ProfessorTurma", b =>
                {
                    b.Property<int>("IdProfessor")
                        .HasColumnType("integer")
                        .HasColumnName("id_professor");

                    b.Property<int>("IdTurma")
                        .HasColumnType("integer")
                        .HasColumnName("id_turma");

                    b.HasKey("IdProfessor", "IdTurma");

                    b.HasIndex("IdTurma");

                    b.ToTable("ProfessorTurma");
                });

            modelBuilder.Entity("Scholl.TurmaModel.Turma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(24)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("tb_Turma", (string)null);
                });

            modelBuilder.Entity("MenuPerfil", b =>
                {
                    b.HasOne("Scholl.Models.Menu", null)
                        .WithMany()
                        .HasForeignKey("MenusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Scholl.Models.Perfil", null)
                        .WithMany()
                        .HasForeignKey("PerfisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Scholl.AlunoTurmamodel.AlunoTurma", b =>
                {
                    b.HasOne("Scholl.AlunoModel.Aluno", "Aluno")
                        .WithMany("AlunosTurmas")
                        .HasForeignKey("IdAluno")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Scholl.TurmaModel.Turma", "Turma")
                        .WithMany("AlunosTurmas")
                        .HasForeignKey("IdTurma")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("Scholl.AvaliacaoModel.Avaliacao", b =>
                {
                    b.HasOne("Scholl.ProfessorModel.Professor", "Professor")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("IdProfessor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("Scholl.AvaliacaoModel.AvaliacaoNota", b =>
                {
                    b.HasOne("Scholl.AlunoModel.Aluno", "Aluno")
                        .WithMany("NotasAvaliacao")
                        .HasForeignKey("IdAluno")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Scholl.AvaliacaoModel.Avaliacao", "Avaliacao")
                        .WithMany("Notas")
                        .HasForeignKey("IdAvaliacao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Avaliacao");
                });

            modelBuilder.Entity("Scholl.HistoricoModel.Historico", b =>
                {
                    b.HasOne("Scholl.AlunoModel.Aluno", "Aluno")
                        .WithMany("Historico")
                        .HasForeignKey("IdAluno")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");
                });

            modelBuilder.Entity("Scholl.Models.AlunoPresenca", b =>
                {
                    b.HasOne("Scholl.AlunoModel.Aluno", "aluno")
                        .WithMany("Presencas")
                        .HasForeignKey("IdAluno")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("aluno");
                });

            modelBuilder.Entity("Scholl.Models.PerfilMenu", b =>
                {
                    b.HasOne("Scholl.Models.Menu", "Menu")
                        .WithMany("MenuPerfil")
                        .HasForeignKey("IdMenu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Scholl.Models.Perfil", "Perfil")
                        .WithMany("MenuPerfil")
                        .HasForeignKey("IdPerfil")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");

                    b.Navigation("Perfil");
                });

            modelBuilder.Entity("Scholl.Models.Usuario", b =>
                {
                    b.HasOne("Scholl.Models.Perfil", "Perfil")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdPerfil")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Perfil");
                });

            modelBuilder.Entity("Scholl.ProfessorModel.Professor", b =>
                {
                    b.HasOne("Scholl.DepartamentoModel.Departamento", null)
                        .WithMany("Professor")
                        .HasForeignKey("DepartamentoId");

                    b.HasOne("Scholl.Models.Usuario", "Usuario")
                        .WithOne("Professor")
                        .HasForeignKey("Scholl.ProfessorModel.Professor", "IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Scholl.ProfessorTurmamodel.ProfessorTurma", b =>
                {
                    b.HasOne("Scholl.ProfessorModel.Professor", "Professor")
                        .WithMany("professorTurma")
                        .HasForeignKey("IdProfessor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Scholl.TurmaModel.Turma", "Turma")
                        .WithMany("ProfessorTurmas")
                        .HasForeignKey("IdTurma")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Professor");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("Scholl.AlunoModel.Aluno", b =>
                {
                    b.Navigation("AlunosTurmas");

                    b.Navigation("Historico");

                    b.Navigation("NotasAvaliacao");

                    b.Navigation("Presencas");
                });

            modelBuilder.Entity("Scholl.AvaliacaoModel.Avaliacao", b =>
                {
                    b.Navigation("Notas");
                });

            modelBuilder.Entity("Scholl.DepartamentoModel.Departamento", b =>
                {
                    b.Navigation("Professor");
                });

            modelBuilder.Entity("Scholl.Models.Menu", b =>
                {
                    b.Navigation("MenuPerfil");
                });

            modelBuilder.Entity("Scholl.Models.Perfil", b =>
                {
                    b.Navigation("MenuPerfil");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Scholl.Models.Usuario", b =>
                {
                    b.Navigation("Professor");
                });

            modelBuilder.Entity("Scholl.ProfessorModel.Professor", b =>
                {
                    b.Navigation("Avaliacoes");

                    b.Navigation("professorTurma");
                });

            modelBuilder.Entity("Scholl.TurmaModel.Turma", b =>
                {
                    b.Navigation("AlunosTurmas");

                    b.Navigation("ProfessorTurmas");
                });
#pragma warning restore 612, 618
        }
    }
}
