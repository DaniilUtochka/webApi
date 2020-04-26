using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webApiNew3.Models
{
    public class Address
    {
        [Key] [Required] public int addressId { get; set; }
        public string zipCode { get; set; }
        public string street { get; set; }
        public string build { get; set; }
        [Required]public Int64? customerId { get; set; }
        [NotMapped][JsonIgnore]public Customer Customer { get; set; }
    }
}