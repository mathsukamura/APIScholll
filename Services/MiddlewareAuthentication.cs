using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using Scholl.Data;
using Microsoft.EntityFrameworkCore;
using Scholl.Models;
using Microsoft.AspNetCore.Authorization;
using Scholl.Helpers;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Scholl.Services
{
    public class MiddlewareAuthentication
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _config;

        public MiddlewareAuthentication(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            _config = config;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var issuer = _config.GetValue<dynamic>("Jwt:Issuer");
            var audience = _config.GetValue<dynamic>("Jwt:Audience");
            var keyJwt = _config.GetValue<dynamic>("Jwt:Key");

            var key = Encoding.ASCII.GetBytes(keyJwt);

            try
            {
                var token = httpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

                if (string.IsNullOrWhiteSpace(token))
                {
                    await _next(httpContext);
                    return;
                }

                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
                SecurityToken validatedToken;
                var claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
                
                var claims = claimsPrincipal.Claims.ToList();

                // adiciona as claims ao contexto de segurança da solicitação


                httpContext.User = new ClaimsPrincipal(new ClaimsIdentity(claims, "custom"));

                await _next(httpContext);


            }
            catch (Exception ex)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }
    }


    public class MyAuthorizeMiddleware
    {
        private readonly RequestDelegate _next;

        public MyAuthorizeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                if (httpContext.Request.Path.Value.EndsWith("/login") || httpContext.Request.Path.Value.EndsWith("swagger/index.html"))
                {
                    await _next(httpContext);

                    return;
                }

                if (!httpContext.User.Identity.IsAuthenticated)
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    return;
                }

                var endPoint = httpContext.GetEndpoint();

                var attribute = endPoint?.Metadata.OfType<AuthorizeUrlAttribute>();

                if (attribute == null)
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    return;
                }

                var context = (AppDbcontext)httpContext.RequestServices.GetService(typeof(AppDbcontext));

                var claim = httpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Sid);

                var idUsuario = claim.Value;

                int id = int.Parse(idUsuario);

                var url = ((AuthorizeUrlAttribute)attribute.First()).Url;

                var acessoPermitido = await context.Usuarios
                    .Join(context.Perfils, u => u.IdPerfil, p => p.Id, (u, p) => new { Usuario = u, Perfil = p })
                    .Join(context.MenuPerfils, up => up.Perfil.Id, mp => mp.IdPerfil, (up, mp) => new { UsuarioPerfil = up, PerfilMenu = mp })
                    .Join(context.Menus, upmp => upmp.PerfilMenu.IdMenu, m => m.Id, (upmp, m) => new { UsuarioPerfilMenu = upmp, Menu = m })
                    .AnyAsync(x => x.UsuarioPerfilMenu.UsuarioPerfil.Usuario.Id == id && x.Menu.Url == url);

                if (acessoPermitido == true)
                {
                    await _next(httpContext);

                    return;
                }
                else
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                }
            }
            catch (Exception ex)
            {

                httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
        }
    }
}
