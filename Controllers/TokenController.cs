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
            if (accountId == null) return StatusCode(400);
            
            // Запрашивается токен по аккаунту
            List<Token> tokenList = _db.Token.Where(t => t.accountId == accountId).ToList();
                
            //Если токена для этого аккаунта нет, то генерится новый записывается
            if (tokenList.Count == 0)
            {
                Token token = CreateToken(accountId);
                Task.Run(() => AddTokenToCookie(token));
                return Ok(token);
            }
            //Если токен по этому аккакунту есть, но он пропал, то обноляется токен в БД и в Куки.
            //Аналогично если токен просто есть. Тогда он просто обновляется в БД и Куки.
            else
            {
                UpdateToken(tokenList[0], accountId);
                Task task = Task.Run(() => this.UpdateTokenToCookie(tokenList[0]));
                return Ok(tokenList[0]);
            }
        }

        public Token CreateToken(int? accountId)
        {
            Token token = new Token()
            {
                token = DateTime.Now.GetHashCode().ToString(),
                expiredIn = DateTime.Now.AddMinutes(5),
                accountId = accountId
            };
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
            Console.WriteLine("Выполянется проверка токена на наличие и пригодность");
            List<Token> tokenInDb = _db.Token.Where(t => t.token == token).ToList();
            if (tokenInDb.Count() == 0 || tokenInDb[0].expiredIn <= DateTime.Now) return false;
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