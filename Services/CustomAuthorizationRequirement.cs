using Microsoft.AspNetCore.Authorization;
using Scholl.Models;

namespace Scholl.Services
{
    public class CustomAuthorizationRequirement : IAuthorizationRequirement 
    { 
        public string Url { get; set; }   
        public CustomAuthorizationRequirement(string url)
        {
            Url = url;
        }
    }
}
