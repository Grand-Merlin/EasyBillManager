using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBillManager.Models
{
    public class Customer
    {
        public int IdCustomer { get; set; }
        public int CategoryId { get; set; }
        public int PaymentTermId { get; set; }
        public string CustomerNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerFaxNumber { get; set; }
        public string CustomerMail { get; set; }
        public string CustomerVatNumber { get; set; }
        public bool RegisteredVat { get; set; }
        public bool IsActive { get; set; }
    }
}
