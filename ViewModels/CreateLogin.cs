using System;
using System.ComponentModel.DataAnnotations;


namespace Scholl.LoginViewModel
{
    public class CreateLoginViewModel
    {
        [Required]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DataRegistro { get; set; } = DateTime.Now;
    }
}