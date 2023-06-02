using Scholl.Data;
using System.Threading.Tasks;
using System;
using Scholl.ProfessorModel;
using Scholl.ProfessorViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Scholl.Services.registradorProfessor.Interfaces;

namespace Scholl.Services.registradorProfessor
{
    public class GerenciarProfessorService : ICriarProfessorService, IDeletarProfessorService, IAlterarProfessorService, IBuscarProfessorService
    {
        private readonly AppDbcontext _context;

        public GerenciarProfessorService(AppDbcontext context) => _context = context;

        public async Task<Professor> PostAsync(CreateProfessorViewModels model)
        {
            var professor = new Professor
            {
                Nome = model.Nome,
                DataNascimento = DateTime.Now,
                DataRegistro = DateTime.Now,
                Sexo = 0,
            };

            await _context.Professores.AddAsync(professor);

            await _context.SaveChangesAsync();

            return professor;
        }
        public async Task<bool> DeleteAsync(int id)
        {

            var professor = await _context
                .Professores
                .FirstOrDefaultAsync(x => x.Id == id);

            if (professor == null)
            {
                return false;
            }

            _context.Professores.Remove(professor);

            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<List<Professor>> GetAsync()
        {
            var professor = await _context.Professores
                .AsNoTracking()
                .ToListAsync();

            return professor;
        }

        public async Task<Professor> GetByIdAsync(int id)
        {
            var professor = await _context
                .Professores
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return professor;
        }
        public async Task<Professor> PutAsync(
            CreateProfessorViewModels model,
            int id)
        {
            var professor = await _context
                .Professores
                .FirstOrDefaultAsync(x => x.Id == id);

            if (professor == null)
            {
                return null;
            }

            professor.Nome = model.Nome;
            professor.DataNascimento = DateTime.Now;
            professor.DataRegistro = DateTime.Now;
            professor.Sexo = 0;

            _context.Professores.Update(professor);

            await _context.SaveChangesAsync();

            return professor;
        }
    }
}
