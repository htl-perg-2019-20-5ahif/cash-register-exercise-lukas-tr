using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CashRegisterApi.Model
{
    public class Product
    {
        [Key]
        [JsonPropertyName("id")]
        public int ID { get; set; }
        [Required]
        [JsonPropertyName("productName")]
        public string ProductName { get; set; }
        [Required]
        [JsonPropertyName("unitPrice")]
        public decimal UnitPrice { get; set; }
    }
}
