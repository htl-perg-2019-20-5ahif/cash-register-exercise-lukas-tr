using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CashRegisterApi;
using CashRegisterApi.Model;
using System.Text.Json.Serialization;

namespace CashRegisterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptsController : ControllerBase
    {
        private readonly CashRegisterContext _context;

        public ReceiptsController(CashRegisterContext context)
        {
            _context = context;
        }

        // GET: api/Receipts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Receipt>>> GetReceipts()
        {
            return await _context.Receipts.ToListAsync();
        }

        // GET: api/Receipts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Receipt>> GetReceipt(int id)
        {
            var receipt = await _context.Receipts.FindAsync(id);

            if (receipt == null)
            {
                return NotFound();
            }

            return receipt;
        }

        // POST: api/Receipts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Receipt>> PostReceipt(List<ReceiptLineDto> receiptLineDto)
        {
            // Read product data from DB for incoming product IDs
            var products = new Dictionary<int, Product>();

            var productsArr = await _context.Products.ToListAsync();
            foreach (var p in productsArr)
            {
                products[p.ID] = p;
            }

            try
            {
                // Build receipt from DTO
                var newReceipt = new Receipt
                {
                    ReceiptTimestamp = DateTime.UtcNow,
                    ReceiptLines = receiptLineDto.Select(rl => new ReceiptLine
                    {
                        ID = 0,
                        BoughtProduct = products[rl.ProductID],
                        Amount = rl.Amount,
                        TotalPrice = rl.Amount * products[rl.ProductID].UnitPrice
                    }).ToList()
                };
                newReceipt.TotalPrice = newReceipt.ReceiptLines.Sum(rl => rl.TotalPrice);
                if (newReceipt.ReceiptLines.Count == 0)
                {
                    return BadRequest();
                }
                _context.Receipts.Add(newReceipt);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetReceipt", new { id = newReceipt.ID }, newReceipt);
            }
            catch (KeyNotFoundException e)
            {
                return BadRequest();
            }
        }
    }

    public class ReceiptLineDto
    {
        [JsonPropertyName("productId")]
        public int ProductID { get; set; }
        [JsonPropertyName("amount")]
        public int Amount { get; set; }
    }
}
