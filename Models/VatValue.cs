using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBillManager.Models
{
    public class VatValue
    {
        public int IdVatValue { get; set; }
        public int CountryId { get; set; }
        public int VatTypeId { get; set; }
        public int VatValueId { get; set; }
    }
}
