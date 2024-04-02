using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBillManager.Models
{
    public class Invoice
    {
       
        public int IdInvoice { get; set; }
        public int CustomerId { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal TotalAmountExcVat { get; set; }
        public decimal TotalAmountVat { get; set; }
        public bool FlagAccounting { get; set; }
        public string Communication { get; set; }

    }
}
