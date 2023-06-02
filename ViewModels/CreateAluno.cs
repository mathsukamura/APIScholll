using Scholl.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Scholl.AlunoViewModel
{
    public class CreateAlunoViewModels
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public ESexo Sexo { get; set; }
        [Required]
        public DateTime Data_Nascimento { get; set; } = DateTime.Now;

    }
}
