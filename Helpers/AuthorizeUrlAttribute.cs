using Microsoft.AspNetCore.Authorization;
using System;

namespace Scholl.Helpers
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AuthorizeUrlAttribute : Attribute
    {
        public AuthorizeUrlAttribute(string url)
        {
            Url = url;
        }

        public string Url { get; set; }
    }
}
