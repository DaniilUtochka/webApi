using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using webApiNew3.Models;

namespace webApiNew3

{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;
        
        public TokenMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.ToString().Contains("/token"))
            {
                Console.WriteLine("Requested \"/token\" from user with cookies len: {0}", context.Request.Cookies.Count);
                await _next.Invoke(context);    
            }
            else await _next.Invoke(context);

        }

    }
}