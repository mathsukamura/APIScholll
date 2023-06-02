using Scholl.AlunoModel;
using Scholl.AlunoViewModel;
using Scholl.Data;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Scholl.Services.RegistradorAluno.Interfaces;

namespace Scholl.Services.Alunos
{
    public class GerenciarAlunoService : IBuscarAlunoService, ICriarAlunoService, IDeletarAlunoService,  IAlterarAlunoService
    {
        private readonly AppDbcontext _context;

        public GerenciarAlunoService(AppDbcontext context) => _context = context;

        public async Task<List<Aluno>> GetAsync()
        {
            var alunos = await _context
                .Alunos
                .AsNoTracking()
                .ToListAsync();

            return alunos;
        }

        public async Task<Aluno> GetByIdAsync(int id)
        {
            var aluno = await _context
                .Alunos
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return aluno;
        }

        public async Task<Aluno> PostAsync(CreateAlunoViewModels model)
        {
            var aluno = new Aluno
            {
                Nome = model.Nome,
                DataNascimento = DateTime.Now,
                DataRegistro = DateTime.Now,
                Sexo = model.Sexo,
            };

            await _context.Alunos.AddAsync(aluno);

            await _context.SaveChangesAsync();

            return aluno;
        }

        public async Task<Aluno> PutAsync(
            [FromBody] CreateAlunoViewModels model, 
            [FromRoute] int id)
        {
            var aluno = await _context
                .Alunos
                .FirstOrDefaultAsync(x => x.Id == id);

            if (aluno == null)
            {
                return null;
            }

            aluno.Nome = model.Nome;
            aluno.DataNascimento = DateTime.Now;
            aluno.DataRegistro = DateTime.Now;
            aluno.Sexo = 0;
                
            _context.Alunos.Update(aluno);

            await _context.SaveChangesAsync();

            return aluno;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var aluno = await _context
                .Alunos
                .FirstOrDefaultAsync(x => x.Id == id);

            if (aluno == null)
            {
                return false;
            }

            _context.Alunos.Remove(aluno);

            await _context.SaveChangesAsync();

            return true;
        }

    }
}

    

