using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using webApiNew3.Models;

namespace webApiNew3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public CustomerController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            List<Customer> Customers = _db.Customers.ToList();
            return ListToSet(Customers);
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> Get(long id)
        {
            var customer = _db.Customers.Find(id);
            return Ok(customer);
        }

        [HttpGet("{id}/info")]
        public ActionResult<Customer> GetInfo(long id)
        {
            Customer customer = _db.Customers.
                Where(c => c.customerId == id)
                .Include(c => c.Address)
                .FirstOrDefault();
            Console.WriteLine("GET: customer/{0}/info - Вызов выполнен успешно", id.ToString());
            return Ok(customer);
        }

        [HttpGet("{id}/address")]
        public ActionResult<Customer> GetAddress(long id)
        {
            Customer customer = _db.Customers
                .Where(c => c.customerId == id) 
                .Include(c => c.Address)
                .First();
            
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Customer Customer)
        {
            _db.Customers.AddAsync(new Customer()
            {
                birthdayDate = Customer.birthdayDate,
                firstName = Customer.firstName,
                lastName = Customer.lastName
            });
            
            await _db.SaveChangesAsync();
            return Ok();
        }

        internal HashSet<T> ListToSet<T>(List<T> list)
        {
            HashSet<T> set = new HashSet<T>();
            foreach (var element in list)
            {
                set.Add(element);
            }
            Console.WriteLine(set.Count);
            return set;
        }
        
    }
}
