using System;
using System.ComponentModel.DataAnnotations;

namespace Scholl.TurmaViewModel
{
    public class CreateTurmaViewModels
    {
        [Required]
        public int Id { get; set; }
        public string Nome { get; set; }

    }
}