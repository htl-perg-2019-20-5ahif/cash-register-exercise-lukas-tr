using CashRegisterApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashRegisterApi
{
    public class CashRegisterContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ReceiptLine> ReceiptLines { get; set; }
        public CashRegisterContext(DbContextOptions<CashRegisterContext> options): base(options) { }
    }
}
