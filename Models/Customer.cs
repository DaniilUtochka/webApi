using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace webApiNew3.Models
{
    public class Customer
    {
        [Key] [Required] public Int64 customerId { get; set; }
        [Required] public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime? birthdayDate { get; set; }
        public List<Address> Address { get; set; }
        [NotMapped] [JsonIgnore] public Account Account { get; set; }
    }
}