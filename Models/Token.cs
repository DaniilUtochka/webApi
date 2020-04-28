using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace webApiNew3.Models
{
    public class Token
    {
        [Key] [Required] public Int64 tokenId { get; set; }
        [Required] public string token { get; set; }
        [Required] public DataType expiredIn { get; set; }

        [JsonIgnore]public Account Account { get; set; }
    }
}