using System;
using Microsoft.EntityFrameworkCore;
using webApiNew3.Models;

namespace webApiNew3.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Account> Account { get; set; }
    }

}
