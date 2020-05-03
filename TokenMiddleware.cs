using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
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
            string path = context.Request.Path.Value.ToLower();
            if (path == "/token" || path == "/api/account/auth")
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
                    
                    await context.Response.WriteAsync("TokenMiddlware: No access, get token before request - GET: /token?accountId = *");
                }
                else
                {
                    // Проверка, если токен есть и он не прорпал, то допускаем пользователя
                    if (new TokenController(applicationContext).CheckToken(tokenInCookies))
                    {
                        Console.WriteLine("TokenMiddlware: Проверка токена выолнена успешно, вызов с токеном: {0}", tokenInCookies);
                        await _next.Invoke(context);
                    }
                    // Если токен невалиден 
                    else
                    {
                        Console.WriteLine("TokenMiddlware: Токен {0} не найден или истек его срок действия", tokenInCookies);
                        await context.Response.WriteAsync("Your token expired, get new sing - GET: /token?accountId = *");
                    }
                }
            }
        }
    }
}