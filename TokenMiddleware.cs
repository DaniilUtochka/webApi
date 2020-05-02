using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;
using Microsoft.VisualBasic;
using webApiNew3.Controllers;
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

        public async Task InvokeAsync(HttpContext context, ApplicationDbContext applicationContext)
        {
            if (context.Request.Path.ToString().Contains("/token"))
            {
                Console.WriteLine("Requested \"GET: /token\"");
                await _next.Invoke(context);
            }
            else
            {
                // Если мы не запращиваем токен, то надо проверить, если ли токен в куки
                // Если токена в куки нет, то надо отказать в получении информации
                // Если токен есть, то проверяет его наличие в БД
                
                String tokenInCookies = context.Request.Cookies["token"];
                if (tokenInCookies == null)
                {
                    
                    await context.Response.WriteAsync("No access, get token before request - GET: /token?accountId = *");
                }
                else
                {
                    if (new TokenController(applicationContext).CheckToken(tokenInCookies))
                    {
                        Console.WriteLine("Проверка токена выолнена успешно, вызов с токеном: {0}", tokenInCookies);
                        await _next.Invoke(context);
                    }
                    else
                    {
                        Console.WriteLine("Токен {0} не найден или истек его срок действия", tokenInCookies);
                        await context.Response.WriteAsync("Your token expired, get new sing - GET: /token?accountId = *");
                    }
                }
            }

        }

    }
}