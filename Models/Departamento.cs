using System;
using Scholl.ProfessorModel;
using System.Collections.Generic;

namespace Scholl.DepartamentoModel
{

    public class Departamento
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Professor> Professor { get; set; }

    }
}
