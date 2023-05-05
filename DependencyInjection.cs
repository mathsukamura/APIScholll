using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scholl.Data;
using Scholl.Services.Alunos;
using Scholl.Services.RegistradorAluno.Interfaces;
using Scholl.Services.registradorProfessor;
using Scholl.Services.registradorProfessor.Interfaces;
using Scholl.Services.RegistrarAvaliacao;
using Scholl.Services.RegistrarAvaliacao.Interfaces;

namespace Scholl
{
    public class DependencyInjection
    {
        public static void ConfigureInterfacesAluno(IServiceCollection services)
        {
            services.AddScoped<ICriarAlunoService, GerenciarAlunoService>();
            services.AddScoped<IDeletarAlunoService, GerenciarAlunoService>();
            services.AddScoped<IBuscarAlunoService, GerenciarAlunoService>();
            services.AddScoped<IAlterarAlunoService, GerenciarAlunoService>();
        }
        public static void ConfigureInterfacesProfessor(IServiceCollection services) 
        {
            services.AddScoped<ICriarProfessorService, GerenciarProfessorService>();
            services.AddScoped<IDeletarProfessorService, GerenciarProfessorService>();
            services.AddScoped<IBuscarProfessorService, GerenciarProfessorService>();
            services.AddScoped<IAlterarProfessorService, GerenciarProfessorService>();
        }
        public static void ConfigureInterfacesAvaliacao(IServiceCollection services) 
        {
            services.AddScoped<ICriarAvalicaoService, GerenciarAvaliacaoService>();
            services.AddScoped<IDeleteAvaliacaoService, GerenciarAvaliacaoService>();
            services.AddScoped<IBuscarAvaliacaoService, GerenciarAvaliacaoService>();
            services.AddScoped<IAlterarAvalicaoService, GerenciarAvaliacaoService>();
        }
    }
}
