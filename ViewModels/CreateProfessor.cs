using System;
using System.ComponentModel.DataAnnotations;

namespace Scholl.ProfessorViewModel
{
    public class CreateProfessorViewModels
    {
        [Required]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public DateTime Data_Nascimento { get; set; } = DateTime.Now;
    }
}