using Microsoft.EntityFrameworkCore;
using Scholl.AvaliacaoModel;
using Scholl.Data;
using Scholl.Models.Enums;
using Scholl.Services.LancarNota.Interface;
using Scholl.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scholl.Services.LancarNota
{
    public class GerenciarNotas: ILancarNota, IBuscarNota, IAlterarNota, IDeletarNota
    {
        private readonly AppDbcontext _context;
        private readonly IUserService _userService;
        public GerenciarNotas(AppDbcontext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }
  
        public async Task<IList<AvaliacaoNota>> GetAsync(EBimestre bimestre) 
        {

            var idUsuario = _userService.ObterUsuarioId();

            var professor = await _context.Professores.FirstOrDefaultAsync(p => p.IdUsuario == idUsuario);

            if (professor == null)
            {
                return null;
            }

            var notas = await _context.AvaliacaoNotas
                .Where(n => n.Avaliacao.Professor.Id == professor.Id && n.Avaliacao.Bimestre == bimestre)
                .AsNoTracking()
                .ToListAsync();

            return notas;
        }

        public async Task<AvaliacaoNota> GetByIdAsync(EBimestre bimestre, int id) 
        {
            var idUsuario = _userService.ObterUsuarioId();

            var professor = await _context.Professores.FirstOrDefaultAsync(p => p.IdUsuario == idUsuario);

            if (professor == null)
            {
                return null;
            }

            var nota = await _context.AvaliacaoNotas
                .Include(n => n.Avaliacao)
                .FirstOrDefaultAsync(n => n.Id == id && n.Avaliacao.Bimestre == bimestre);

            return nota;
        }

        public async Task<AvaliacaoNota> PostAsync(CreateAvaliacaoNota model, EBimestre bimestre, int id)
        {
            var idUsuario = _userService.ObterUsuarioId();

            var professor = await _context.Professores.FirstOrDefaultAsync(p => p.IdUsuario == idUsuario);

            if (professor == null)
            {
                return null;
            }

            var avaliacao = await _context.Avaliacoes.FirstOrDefaultAsync(a => a.Id == id && a.Bimestre == bimestre);

            if (avaliacao != null) 
            {
                return null;
            }

            var nota = model.ToEntity();

            await _context.AvaliacaoNotas.AddAsync(nota);

            await _context.SaveChangesAsync();

            return nota;
        }

        public async Task<AvaliacaoNota> PutAsync(CreateAvaliacaoNota model, EBimestre bimestre, int id)
        {
            var idUsuario = _userService.ObterUsuarioId();

            var professor = await _context.Professores.FirstOrDefaultAsync(p => p.IdUsuario == idUsuario);

            if (professor == null)
            {
                return null;
            }

            var nota = await _context.AvaliacaoNotas
                .Include(n => n.Avaliacao)
                .FirstOrDefaultAsync(n => n.Id == id);


            if (nota.Avaliacao.Bimestre != bimestre)
            {
                return null;
            }

            if (nota == null)
            {
                return null;
            }

            if(nota.IdAvaliacao != model.IdAvaliacao) 
            {
                return null;
            }

            if (nota.Avaliacao.Professor.Id != professor.Id)
            {
                return null;
            }

            nota.AtualizaNota(model);

            await _context.SaveChangesAsync();

            return nota;
        }

        public async Task<bool> DeleteAsync(EBimestre bimestre, int id) 
        {
            var idUsuario = _userService.ObterUsuarioId();

            var professor = await _context.Professores.FirstOrDefaultAsync(p => p.IdUsuario == idUsuario);

            if (professor == null)
            {
                return false;
            }

            var nota = await _context.AvaliacaoNotas
                .Include(n => n.Avaliacao)
                .FirstOrDefaultAsync(n => n.Id == id);

            if (nota.Avaliacao.Bimestre != bimestre)
            {
                return false;
            }

            if (nota == null)
            {
                return false;
            }
            _context.AvaliacaoNotas.Remove(nota);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
