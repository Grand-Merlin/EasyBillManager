using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBillManager.Models
{
    public class Address
    {
        public int IdAddress { get; set; }
        public int CityId { get; set; }
        public string AddressLine { get; set; }
        public string AddressNumber { get; set; }
        public string AddressBox { get; set; }
        public string AddressComplement { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
    }
}
