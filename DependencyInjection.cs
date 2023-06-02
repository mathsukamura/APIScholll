using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scholl.Data;
using Scholl.Services;
using Scholl.Services.Alunos;
using Scholl.Services.ControleMenu;
using Scholl.Services.ControleMenu.Interface;
using Scholl.Services.FinalizarBimestre;
using Scholl.Services.FinalizarBimestre.Interface;
using Scholl.Services.GerarToken;
using Scholl.Services.GerarToken.Interface;
using Scholl.Services.LancarNota;
using Scholl.Services.LancarNota.Interface;
using Scholl.Services.RegistradorAluno.Interfaces;
using Scholl.Services.registradorProfessor;
using Scholl.Services.registradorProfessor.Interfaces;
using Scholl.Services.RegistrarAvaliacao;
using Scholl.Services.RegistrarAvaliacao.Interfaces;
using Scholl.Services.Registrarperfil;
using Scholl.Services.Registrarperfil.Interface;
using Scholl.Services.RegistrarUsuario;
using Scholl.Services.RegistrarUsuario.Interface;

namespace Scholl
{
    public class DependencyInjection
    {
        public static void ConfigureInterfaces(IServiceCollection services) 
        {
            
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IRepositorioAluno, FecharDiario>();
            services.AddScoped<IRepositorioAvaliacao, FecharDiario>();
            services.AddScoped<IRepositorioAvaliacaoNota, FecharDiario>();
            services.AddScoped<IRepositorioHistorico, FecharDiario>();

            //avaliaçãonota
            services.AddScoped<ILancarNota, GerenciarNotas>();
            services.AddScoped<IBuscarNota, GerenciarNotas>();
            services.AddScoped<IDeletarNota, GerenciarNotas>();
            services.AddScoped<IAlterarNota, GerenciarNotas>();

            //aluno
            services.AddScoped<ICriarAlunoService, GerenciarAlunoService>();
            services.AddScoped<IDeletarAlunoService, GerenciarAlunoService>();
            services.AddScoped<IBuscarAlunoService, GerenciarAlunoService>();
            services.AddScoped<IAlterarAlunoService, GerenciarAlunoService>();
            //professor
            services.AddScoped<ICriarProfessorService, GerenciarProfessorService>();
            services.AddScoped<IDeletarProfessorService, GerenciarProfessorService>();
            services.AddScoped<IBuscarProfessorService, GerenciarProfessorService>();
            services.AddScoped<IAlterarProfessorService, GerenciarProfessorService>();
            //avaliação
            services.AddScoped<ICriarAvalicaoService, GerenciarAvaliacaoService>();
            services.AddScoped<IDeleteAvaliacaoService, GerenciarAvaliacaoService>();
            services.AddScoped<IBuscarAvaliacaoService, GerenciarAvaliacaoService>();
            services.AddScoped<IAlterarAvalicaoService, GerenciarAvaliacaoService>();
            //usuario
            services.AddScoped<ICriarUsuarioService, GerenciarUsuarioService>();
            services.AddScoped<IBuscarUsuarioService, GerenciarUsuarioService>();
            services.AddScoped<IAlterarUsuarioService, GerenciarUsuarioService>();
            services.AddScoped<IDeletarUsarioService, GerenciarUsuarioService>();
            //perfil
            services.AddScoped<IBuscarPerfilService, GerenciarPerfilService>();
            services.AddScoped<ICriarPerfilService, GerenciarPerfilService>();
            services.AddScoped<IAlterarPerfilService, GerenciarPerfilService>();
            services.AddScoped<IDeletarPerfilService, GerenciarPerfilService>();
            //menu
            services.AddScoped<IBuscarMenuService, GerenciarMenuService>();
            services.AddScoped<ICriarMenuService, GerenciarMenuService>();
            services.AddScoped<IAlterarMenuService, GerenciarMenuService>();
            services.AddScoped<IDeletarMenuService, GerenciarMenuService>();
            //autenticação
            services.AddSingleton<ITokenService, TokenService>();
            services.AddScoped<IAutenticarUsuario, AutenticarUsuarioService>();

        }
    }
}
