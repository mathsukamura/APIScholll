using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Scholl.Services.GerarToken.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using Scholl.Models;

namespace Scholl.Services.GerarToken
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;

        public TokenService(IConfiguration config)
        {
            _config = config;
        }

        public string GerarToken(Usuario usuarios)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var issuer = _config.GetValue<dynamic>("Jwt:Issuer");
            var audience = _config.GetValue<dynamic>("Jwt:Audience");
            var keyJwt = _config.GetValue<dynamic>("Jwt:Key");

            var key = Encoding.ASCII.GetBytes(keyJwt);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sid, usuarios.Id.ToString()),    
                        //new Claim(JwtRegisteredClaimNames.Email, usuarios.Email),
                        //new Claim(ClaimTypes.Role, usuarios.Perfil.TipoPerfil),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    }
                ),
                Expires = DateTime.UtcNow.AddHours(2),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
