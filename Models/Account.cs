using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace webApiNew3.Models
{
    public class Account
    {
        [Key][Required]public int accountId { get; set; }
        public Int64 customerId { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public Customer Customer { get; set; }
        [NotMapped][JsonIgnore] public Token Token { get; set; }
    }
}