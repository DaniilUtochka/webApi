using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult> get()
        {
            Console.WriteLine(HttpContext.Request?.Headers["Token"].ToString());

            return Ok();
        }

    }
}