using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBillManager.Models
{
    public class AddressAddressTypeCustomer
    {
        public int IdAddressAddressTypeCustomer { get; set; }
        public int AddressId { get; set; }
        public int AddressTypeId { get; set; }
        public int CustomerId { get; set; }
    }
}
