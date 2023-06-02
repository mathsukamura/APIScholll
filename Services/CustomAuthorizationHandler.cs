using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace Scholl.Services
{
    public class AuthorizeMenuAttribute : IAuthorizationHandler
    {
        public Task HandleAsync(AuthorizationHandlerContext context)
        {
            throw new NotImplementedException();
        }
    }


    public class CustomAuthorizationHandler : IAuthorizationHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomAuthorizationHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Task HandleAsync(AuthorizationHandlerContext context)
        {
            
            var user = _httpContextAccessor.HttpContext.User;

            foreach (var requirement in context.Requirements)
            {
                if (requirement is CustomAuthorizationRequirement customRequirement)
                {
                    if (user.Claims.Any(c => c.Type == "Url" && c.Value == customRequirement.Url))
                    {
                        context.Succeed(requirement);
                    }
                    var url = context.Resource.ToString();
                    if (url.Contains(customRequirement.Url))
                    {
                        context.Succeed(requirement);
                    }
                    else
                    {
                        context.Fail();
                    }
                }
            }

            return Task.CompletedTask;
        }
    }
}