using Microsoft.EntityFrameworkCore;
using Scholl.AlunoModel;
using Scholl.ProfessorModel;
using Scholl.LoginModel;
using Scholl.TurmaModel;
using Scholl.AvaliacaoModel;
using System.Reflection;
using Scholl.Models;
using System.Text.RegularExpressions;
using System;
using Scholl.HistoricoModel;

namespace Scholl.Data
{
    public class AppDbcontext : DbContext
    {
        public AppDbcontext()
        {
        }

        public AppDbcontext(DbContextOptions<AppDbcontext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<AvaliacaoNota> AvaliacaoNotas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Perfil> Perfils { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<PerfilMenu> MenuPerfils { get; set; }
        public DbSet<Historico> Historicos { get; set; }

        //     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseNpgsql(connectionString: "Default");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entity.GetProperties())
                {
                    if (property.GetDefaultColumnBaseName() != property.GetColumnBaseName()) continue;
                    var columnname = property.GetDefaultColumnBaseName().ToSnakeCase();
                    property.SetColumnName(columnname);
                }
            }
        }

    }
    public static class StringExtensions
    {
        public static string ToSnakeCase(this string input)
        {
            if (string.IsNullOrEmpty(input)) { return input; }

            var startUnderscores = Regex.Match(input, @"^_+");
            return startUnderscores + Regex.Replace(input, @"([a-z0-9])([A-Z])", "$1_$2").ToLower();
        }
    }
}