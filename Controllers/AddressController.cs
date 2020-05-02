using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using webApiNew3.Models;

namespace webApiNew3.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class AddressController: ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public AddressController(ApplicationDbContext db)
        {
             _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Address>> Get()
        {
            return _db.Addresses.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Address> Get(int id)
        {
            Address address = _db.Addresses.Find(id);
            return address;
        }
        

    }
}