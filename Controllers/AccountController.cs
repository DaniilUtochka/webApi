using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApiNew3.Models;

namespace webApiNew3.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AccountController: ControllerBase
    {
        private readonly ApplicationDbContext _db;
        
        public AccountController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        [HttpGet]
        public ActionResult<List<Account>> Get()
        {
            return Ok(_db.Account.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Account> Get(int id)
        {
            Account account = _db.Account
                .Where(a => a.accountId == id)
                .Include(a => a.Customer)
                .FirstOrDefault();
            if (account == null)
            { return NotFound("Такого аккаунта неть"); }
            else { return Ok(account); }
        }
        
        // Auth get method
        [HttpGet("auth")]
        public async Task<ActionResult<Boolean>> GetAuth([FromQuery] string login,[FromQuery] string password )
        {
            if (login == null || password == null) return BadRequest("Check request parameters");

            Account Account = await _db.Account
                .Where(a => a.login.ToLower() == login.ToLower() && a.password == password)
                .FirstOrDefaultAsync();
            if (Account == null)
            {
                Console.WriteLine("Incorrect login or password");
                return StatusCode(403, "Incorrect login or password");
            }
            
            // Вызов метода получения токена
            if (new TokenController(_db).get(Account.accountId).IsCompleted) return Ok(true);
            else return StatusCode(500, "Undef error");
        }
        
        
        // For auth from ui form 
        [HttpPost]
        public ActionResult<Account> PostAuth(int id)
        {
            return null;
        }
        
    }
}