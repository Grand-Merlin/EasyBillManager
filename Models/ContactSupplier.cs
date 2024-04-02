using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBillManager.Models
{
    public class ContactSupplier
    {
        public int IdContactSupplier { get; set; }
        public int SupplierId { get; set; }
        public int ContactId { get; set; }
        public string PhoneNumberPro { get; set; }
        public string MailPro { get; set; }

    }
}
