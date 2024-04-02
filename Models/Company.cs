using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBillManager.Models
{
    public class Company
    {
        public int IdCompagny { get; set; }
        public string CompanyName { get; set; }
        public string VatNumber { get; set; }
        public string PhoneNumberGeneral { get; set; }
        public string MailGeneral { get; set; }
        public string BankName { get; set; }
        public string BankIban { get; set; }
        public string BankBic { get; set; }
    }
}
