using Microsoft.Net.Http.Headers;
using Scholl.AvaliacaoViewModel;
using Scholl.Models.Enums;
using Scholl.ProfessorModel;
using Scholl.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace Scholl.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ESexo Sexo { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int IdPerfil { get; set; }
        public DateTime DataNascimento { get; set; }
        public Perfil Perfil { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public EProfessor Eprofessor { get; set; }
        public Professor Professor { get; set; }

        public Usuario()
        {
            Professor = new Professor();
        }

        public void AtualizacaoUserViewModel(CreateUsuarioViewModel viewModel)
        {
            if (viewModel == null)
            {
                return;
            }

            Name = viewModel.Name;
            Email = viewModel.Email;
            Senha = viewModel.Senha;
            IdPerfil = viewModel.IdPerfil;
            DataNascimento = viewModel.DataNascimento;
        }
    }
}
