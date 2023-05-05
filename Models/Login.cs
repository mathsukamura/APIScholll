using System.Reflection;
using Scholl.AlunoModel;
using Scholl.ProfessorModel;
using System;


namespace Scholl.LoginModel
{
    public class Login
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DataRegistro { get; set; } = DateTime.Now;
    }
}