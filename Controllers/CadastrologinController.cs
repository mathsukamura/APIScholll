using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Scholl.LoginViewModel;
using Scholl.LoginModel;
using System;
using Scholl.Data;

namespace Scholl.CadastrarLoginController
{
    class CadastrarLogin : ControllerBase
    {
        [HttpPost("login")]

        public async Task<IActionResult> PostAsync(
        [FromServices] AppDbcontext context,
        [FromBody] CreateLoginViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var Login = new Login
            {
                Username = model.Username,
                Password = model.Password,
                Email = model.Email,
                Phone = model.Phone,
                DataRegistro = DateTime.Now,
            };
            try
            {
                await context.Logins.AddAsync(Login);
                await context.SaveChangesAsync();
                return Created($"v1/CadastrarLogin/{Login.Id}", Login);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}