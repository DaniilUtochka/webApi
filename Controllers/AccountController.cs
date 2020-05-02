using System.Collections.Generic;
using System.Linq;
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
                .Include(a => a.Customer)
                .Where(a => a.accountId == id)
                .FirstOrDefault();
            if (account == null)
            { return NotFound(); }
            else { return Ok(account); }
        } 
    }
}