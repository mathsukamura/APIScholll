using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Scholl.AvaliacaoModel;
using Scholl.AvaliacaoViewModel;
using Scholl.Data;
using Scholl.Models;
using Scholl.ProfessorModel;
using Scholl.Services.RegistrarAvaliacao.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Scholl.Services.RegistrarAvaliacao
{
    public class GerenciarAvaliacaoService: ICriarAvalicaoService, IAlterarAvalicaoService, IBuscarAvaliacaoService, IDeleteAvaliacaoService
    {

        private readonly AppDbcontext _context;
        private readonly IUserService _userService;

        public GerenciarAvaliacaoService(IUserService userService, AppDbcontext context)
        {
            _userService = userService;
            _context = context;
        }

        public async Task<List<Avaliacao>> GetAsync() 
        {
            var idUsuario = _userService.ObterUsuarioId();

            var professor = await _context.Professores.FirstOrDefaultAsync(p => p.IdUsuario == idUsuario);

            if (professor == null)
            {
                return null;
            }

            var avaliacoes = await _context.Avaliacoes
                .Where(a => a.Professor.Id == professor.Id) 
                .AsNoTracking()
                .ToListAsync();

            return avaliacoes;
        }

        public async Task<Avaliacao> GetByIdAsync(int id) 
        {
            var idUsuario = _userService.ObterUsuarioId();

            var professor = await _context.Professores.FirstOrDefaultAsync(p => p.IdUsuario == idUsuario);

            if (professor == null)
            {
                return null;
            }

            var avaliacao = await _context.Avaliacoes
                .Where(a => a.Professor.Id == professor.Id && a.Id == id) 
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return avaliacao;
        }

        public async Task<Avaliacao> PostAsync(CreateAvaliacaoViewModel model) 
        {
            var idUsuario = _userService.ObterUsuarioId();

            var professor = await _context.Professores.FirstOrDefaultAsync(p => p.IdUsuario == idUsuario);
            
            if (professor == null)
            {
                return null; 
            }
            
            var avaliacao = model.ToEntity();

            avaliacao.IdProfessor = professor.Id;


            await _context.Avaliacoes.AddAsync(avaliacao);

            await _context.SaveChangesAsync();

            return avaliacao;
        }

        public async Task<Avaliacao> PutAsync(int id, CreateAvaliacaoViewModel model) 
        {
            var avaliacao = await _context.Avaliacoes.FindAsync(id);

            if (avaliacao == null)
            {
                return null;
            }

            var idUsuario = _userService.ObterUsuarioId();

            var professor = await _context.Professores.FirstOrDefaultAsync(p => p.IdUsuario == idUsuario);

            if (avaliacao.IdProfessor != professor.Id)
            {
                return null;
            }

            avaliacao.AtualizacaoViewModel(model);

            await _context.SaveChangesAsync();

            return avaliacao;
        }

        public async Task<bool> DeleteAsync(int id) 
        {
            var avaliacao = await _context.Avaliacoes.FirstOrDefaultAsync(x => x.Id == id);

            if(avaliacao == null) 
            {
                return false;
            }

            var idUsuario = _userService.ObterUsuarioId();

            var professor = await _context.Professores.FirstOrDefaultAsync(p => p.IdUsuario == idUsuario);

            if (avaliacao.IdProfessor != professor.Id)
            {
                return false;
            }

            _context.Avaliacoes.Remove(avaliacao);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
