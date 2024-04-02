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
        [JsonProperty("id")]
        public int IdInvoice { get; set; }
        [JsonProperty("customer_id")]
        public int CustomerId { get; set; }
        [JsonProperty("invoice_number")]
        public string InvoiceNumber { get; set; }
        [JsonProperty("invoice_date")]
        public DateTime InvoiceDate { get; set; }
        [JsonProperty("due_date")]
        public DateTime DueDate { get; set; }
        [JsonProperty("total_amount_exc_vat")]
        public decimal TotalAmountExcVat { get; set; }
        [JsonProperty("total_amount_vat")]
        public decimal TotalAmountVat { get; set; }
        [JsonProperty("flag_accounting")]
        public bool FlagAccounting { get; set; }
        [JsonProperty("communication")]
        public string Communication { get; set; }

    }
}
