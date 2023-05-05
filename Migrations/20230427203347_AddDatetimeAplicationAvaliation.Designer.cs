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
    [Migration("20230427203347_AddDatetimeAplicationAvaliation")]
    partial class AddDatetimeAplicationAvaliation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Scholl.AlunoModel.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

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
                        .HasColumnType("integer");

                    b.Property<int>("IdTurma")
                        .HasColumnType("integer");

                    b.HasKey("IdAluno", "IdTurma");

                    b.HasIndex("IdTurma");

                    b.ToTable("AlunoTurma");
                });

            modelBuilder.Entity("Scholl.AvaliacaoModel.Avaliacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Bimestre")
                        .HasColumnType("int")
                        .HasColumnName("Bimestre");

                    b.Property<DateTime>("DataAplicacao")
                        .HasColumnType("timestamp")
                        .HasColumnName("Data_Aplicacao");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(24)")
                        .HasColumnName("descricao");

                    b.Property<int>("IdProfessor")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IdProfessor");

                    b.ToTable("tb_avaliacao", (string)null);
                });

            modelBuilder.Entity("Scholl.AvaliacaoModel.AvaliacaoNota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataRealizacao")
                        .HasColumnType("timestamp")
                        .HasColumnName("data_registro");

                    b.Property<int>("IdAluno")
                        .HasColumnType("integer");

                    b.Property<int>("IdAvaliacao")
                        .HasColumnType("integer");

                    b.Property<float>("Nota")
                        .HasColumnType("float")
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
                        .HasColumnType("integer");

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
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(24)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("tb_departamento", (string)null);
                });

            modelBuilder.Entity("Scholl.LoginModel.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataRegistro")
                        .HasColumnType("timestamp")
                        .HasColumnName("Data_Registro");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("Email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(24)")
                        .HasColumnName("Senha");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("varchar(15)")
                        .HasColumnName("n_celular");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(24)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("tb_login", (string)null);
                });

            modelBuilder.Entity("Scholl.ProfessorModel.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("timestamp")
                        .HasColumnName("Data_Nascimento");

                    b.Property<DateTime>("DataRegistro")
                        .HasColumnType("timestamp")
                        .HasColumnName("Data_Registro");

                    b.Property<string>("DepartamentoId")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("nome");

                    b.Property<int>("Sexo")
                        .HasColumnType("int")
                        .HasColumnName("Sexo");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("tb_Professor", (string)null);
                });

            modelBuilder.Entity("Scholl.ProfessorTurmamodel.ProfessorTurma", b =>
                {
                    b.Property<int>("IdProfessor")
                        .HasColumnType("integer");

                    b.Property<int>("IdTurma")
                        .HasColumnType("integer");

                    b.HasKey("IdProfessor", "IdTurma");

                    b.HasIndex("IdTurma");

                    b.ToTable("ProfessorTurma");
                });

            modelBuilder.Entity("Scholl.TurmaModel.Turma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(24)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("tb_Turma", (string)null);
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
                        .WithMany("Avaliacao")
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

            modelBuilder.Entity("Scholl.ProfessorModel.Professor", b =>
                {
                    b.HasOne("Scholl.DepartamentoModel.Departamento", null)
                        .WithMany("Professor")
                        .HasForeignKey("DepartamentoId");
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

                    b.Navigation("Avaliacao");
                });

            modelBuilder.Entity("Scholl.AvaliacaoModel.Avaliacao", b =>
                {
                    b.Navigation("Notas");
                });

            modelBuilder.Entity("Scholl.DepartamentoModel.Departamento", b =>
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