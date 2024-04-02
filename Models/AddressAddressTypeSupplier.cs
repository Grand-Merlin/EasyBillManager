using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBillManager.Models
{
    public class AddressAddressTypeSupplier
    {
        public int IdAddressAddressTypeSupplier { get; set; }
        public int AddressId { get; set; }
        public int AddressTypeId { get; set; }
        public int SupplierId { get; set; }
    }
}
