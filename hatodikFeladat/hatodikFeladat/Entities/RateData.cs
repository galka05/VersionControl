using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hatodikFeladat.Entities
{
    public class RateData
    {
        public DateTime date { get; set; }  
        public string Currency { get; set; }
        public decimal Value { get; set; }
    }
}
