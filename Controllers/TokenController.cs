using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApiNew3.Models;


namespace webApiNew3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public TokenController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<Token>> get([FromQuery] int? accountId)
        {
            if (accountId == null) return BadRequest();
            
            // Get token by account id
            Token token = _db.Token.Where(t => t.accountId == accountId).FirstOrDefault();
                
            // Create token, if returns nothing
            if (token == null)
            {
                Token tokenNew = CreateToken(accountId); // Token generated and saved to db
                Task.Run(() => AddTokenToCookie(tokenNew)); // Token Saved to cookie
                return Ok(tokenNew);
            }
            // If token expited, refresh and save to DB and cookie
            // Same if token exists and still actual
            else
            {
                UpdateToken(token, accountId);
                Task task = Task.Run(() => this.UpdateTokenToCookie(token));
                return Ok(token);
            }
        }

        // Отдельно сделать генерацию токена, отдельно сохранение
        // Requets from account controller after success authorisation
        public Token CreateToken(int? accountId)
        {
            // Create token
            Token token = new Token()
            {
                token = DateTime.Now.GetHashCode().ToString(),
                expiredIn = DateTime.Now.AddMinutes(5),
                accountId = accountId
            };
            
            // Save token to DB -> to new method
            _db.Token.Add(token);
            _db.SaveChanges();

            return token;
        }
        
        // Метод вызывается для обновления токена клиента, если токен у него был, но уже пропал
        public void UpdateToken(Token token, int? accountId)
        {
            token.expiredIn = DateTime.Now.AddMinutes(5);
            _db.SaveChanges();
        }

        // Метод для проверки валидоности и актуальности токена. Вызыавется из MiddleWare
        public Boolean CheckToken(String token)
        {
            Console.WriteLine("TokenController.CheckToken: Выполянется проверка токена на валидность");
            Token tokenInDb = _db.Token.Where(t => t.token == token).FirstOrDefault();
            if (tokenInDb == null || tokenInDb.expiredIn <= DateTime.Now) return false;
            else return true;
        }

        public async Task AddTokenToCookie(Token token)
        {
            CookieOptions options = new CookieOptions() { Path = "/", Expires = token.expiredIn.AddMinutes(15)};
            Response.Cookies.Append("token", token.token, options);
        }

        public async Task UpdateTokenToCookie(Token token)
        {
            CookieOptions options = new CookieOptions() { Path = "/", Expires = token.expiredIn.AddMinutes(15)};
            Response.Cookies.Delete("token");
            Response.Cookies.Append("token", token.token, options);
        }
    }
}