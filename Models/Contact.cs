using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBillManager.Models
{
    public class Contact
    {
        public int IdContact { get; set; }
        public int AddressId { get; set; }
        public string ContactName { get; set; }
        public string ContactFirstname { get; set; }
        public string PhoneNumberPrivate { get; set; }
        public string MailPrivate { get; set; }

    }
}
