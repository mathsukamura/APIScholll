using Scholl.Models.Enums;
using Scholl.ProfessorModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace Scholl.ProfessorViewModel
{
    public class CreateProfessorViewModels
    {
        [Required]
        public int Id { get; set; }
        public string Nome { get; set; }
        public ESexo Sexo { get; set; }
        public DateTime DataNascimento { get; set; }

        public Professor CreateProfessor()
        {
            var professor = new Professor
            {
                Nome = this.Nome,
                DataRegistro = DateTime.Now,
                Sexo = this.Sexo,
                DataNascimento = this.DataNascimento
            };

            return professor;
        }
    }
}