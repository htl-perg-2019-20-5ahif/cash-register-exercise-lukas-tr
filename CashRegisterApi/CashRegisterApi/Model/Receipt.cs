using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CashRegisterApi.Model
{
    public class Receipt
    {
        [Key]
        [JsonPropertyName("id")]
        public int ID { get; set; }
        [JsonPropertyName("receiptLines")]
        public List<ReceiptLine> ReceiptLines { get; set; }
        [JsonPropertyName("receiptTimestamp")]
        public DateTime ReceiptTimestamp { get; set; }
        [JsonPropertyName("totalPrice")]
        public decimal TotalPrice { get; set; }
    }
}
