using Microsoft.EntityFrameworkCore;
using Scholl.AlunoModel;
using Scholl.ProfessorModel;
using Scholl.LoginModel;
using Scholl.TurmaModel;
using Scholl.AvaliacaoModel;
using System.Reflection;



namespace Scholl.Data
{
    public class AppDbcontext : DbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options) : base(options)
        {
        }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        //     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseNpgsql(connectionString: "Default");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}