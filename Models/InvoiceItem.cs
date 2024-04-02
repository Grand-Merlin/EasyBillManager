using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBillManager.Models
{
    public class InvoiceItem
    {
        public int IdIvoiceItem { get; set; }
        public int InvoiceId { get; set; }
        public int ItemId { get; set; }
        public int VatTypeId { get; set; }
        public decimal VatValue { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal Discount { get; set; }

    }
}
