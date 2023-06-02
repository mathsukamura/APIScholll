using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scholl.Data;
using Scholl.Models;
using Scholl.Services;
using System.Linq;


namespace Scholl.Helpers;

//public class PermissaoAttribute : ActionFilterAttribute
//{
//    private readonly IUserService _userService;

//    public PermissaoAttribute(IUserService userService)
//    {
//        _userService = userService;
//    }
//    public string[] ObterRolesDoUsuario(int usuarioId)
//    {
//        using (var context = new AppDbcontext()) 
//        {
//            var roles = context.Usuarios
//                .Where(u => u.Id == usuarioId)
//                .SelectMany(u => u.Perfil.MenuPerfil)
//                .Where(pm => pm.Get || pm.Post || pm.Put || pm.Delete) 
//                .Select(pm => pm.Perfil.TipoPerfil)
//                .ToArray();

//            return roles;
//        }
//    }

//    public PerfilMenu ObterPerfilMenu(int idPerfil, int idMenu)
//    {
//        using (var context = new AppDbcontext()) 
//        {
//            var perfilMenu = context.MenuPerfils
//                .FirstOrDefault(pm => pm.IdPerfil == idPerfil && pm.IdMenu == idMenu);

//            return perfilMenu;
//        }
//    }

//    public override void OnActionExecuting(ActionExecutingContext context)
//    {
//        var usuarioId = _userService.ObterUsuarioId();
//        var usuarioRoles = ObterRolesDoUsuario(usuarioId);

//        // Verifique se o usuário possui permissão para acessar o endpoint
//        if (!VerificarPermissao(context, usuarioRoles))
//        {
//            context.Result = new ForbidResult();
//            return;
//        }

//        base.OnActionExecuting(context);
//    }

//    private bool VerificarPermissao(ActionExecutingContext context, string[] usuarioRoles)
//    {
//        var perfilMenu = ObterPerfilMenu();

//        // Verifique as permissões com base nas informações de PerfilMenu
//        if (context.HttpContext.Request.Method == "GET" && !perfilMenu.Get)
//        {
//            return false;
//        }
//        if (context.HttpContext.Request.Method == "POST" && !perfilMenu.Post)
//        {
//            return false;
//        }
//        if (context.HttpContext.Request.Method == "PUT" && !perfilMenu.Put)
//        {
//            return false;
//        }
//        if (context.HttpContext.Request.Method == "DELETE" && !perfilMenu.Delete)
//        {
//            return false;
//        }

//        // Verifique se o usuário possui pelo menos uma das roles necessárias
//        return usuarioRoles.Intersect(perfilMenu.Perfil.Roles).Any();
//    }
//}