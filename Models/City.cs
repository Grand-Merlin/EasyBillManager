using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBillManager.Models
{
    public class City
    {
        public int IdCity { get; set; }
        public int CountryId { get; set; }
        public string CityName { get; set; }
        public string ZipCode { get; set; }

    }
}
