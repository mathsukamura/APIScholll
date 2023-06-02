//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;
//using Scholl.Data;
//using System.Linq;

//public class ChecarAcessoAttribute : ActionFilterAttribute
//{
//    public override void OnActionExecuting(ActionExecutingContext context)
//    {
//        var userId = "";
//        var menuUrl = "";

//        using (var db = new AppDbcontext())
//        {
//            var acessoPermitido = (from u in db.Usuarios
//                                   join p in db.Perfils on u.IdPerfil equals p.Id
//                                   join mp in db.MenuVsPerfil on p.Id equals mp.IdPerfil
//                                   join m in db.Menus on mp.IdMenu equals m.Id
//                                   where u.Id == userId && m.Url == menuUrl
//                                   select u.Id).Any();

//            if (!acessoPermitido)
//            {
//                context.Result = new ForbidResult();
//                return;
//            }
//        }

//        base.OnActionExecuting(context);
//    }
//}