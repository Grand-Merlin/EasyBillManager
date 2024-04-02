using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBillManager.Models
{
    public class Item
    {
        public int IdItem { get; set; }
        public int VatTypeId { get; set; }
        public int SupplierId { get; set; }
        public string ItemNumber { get; set; }
        public string SupplierNumber { get; set; }
        public string BarCode { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public decimal PurchasePrice { get; set; }
    }
}
