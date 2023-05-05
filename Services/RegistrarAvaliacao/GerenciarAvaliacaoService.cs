using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Scholl.AvaliacaoModel;
using Scholl.AvaliacaoViewModel;
using Scholl.Data;
using Scholl.ProfessorModel;
using Scholl.Services.RegistrarAvaliacao.Interfaces;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Scholl.Services.RegistrarAvaliacao
{
    public class GerenciarAvaliacaoService: ICriarAvalicaoService, IAlterarAvalicaoService, IBuscarAvaliacaoService, IDeleteAvaliacaoService
    {

        private readonly AppDbcontext _context;

        public GerenciarAvaliacaoService(AppDbcontext context) => _context = context;

        public async Task<Avaliacao> PostAsync(CreateAvaliacaoViewModel model) 
        {
            var professor = await _context.Professores.FindAsync(model.IdProfessor);

            if (professor == null)
            {
                return null; 
            }
            
            var avaliacao = model.ToEntity();

            await _context.Avaliacoes.AddAsync(avaliacao);

            await _context.SaveChangesAsync();

            return avaliacao;
        }

        public async Task<Avaliacao> PutAsync(CreateAvaliacaoViewModel model, int id) 
        {
            var avaliacao = await _context.Avaliacoes.FindAsync(id);

            if (avaliacao == null)
            {
                return null;
            }

            if (avaliacao.IdProfessor != model.IdProfessor)
            {
                return null;
            }

            avaliacao.AtualizacaoViewModel(model);

            await _context.SaveChangesAsync();

            return avaliacao;
        }

        public async Task<bool> DeleteAsync( CreateAvaliacaoViewModel model, int id) 
        {
            var avaliacao =await _context.Avaliacoes.FirstOrDefaultAsync(x => x.Id == id);

            if(avaliacao == null) 
            {
                return false;
            }
            if (avaliacao.IdProfessor != model.IdProfessor)
            {
                return false;
            }

            _context.Avaliacoes.Remove(avaliacao);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Avaliacao>> GetAsync() 
        {
            var avaliacao = await _context.Avaliacoes.AsNoTracking().ToListAsync();

            return avaliacao;
        }
        public async Task<Avaliacao> GetByIdAsync(int id) 
        {
            var avaliacao = await _context.Avaliacoes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            return avaliacao;
        }
    }
}
