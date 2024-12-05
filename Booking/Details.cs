using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_Testing.Booking
{
    internal class Details
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int totalprice { get; set; }
        public bool depositpaid { get; set; }
        public Dates bookingdates { get; set; }
        public string additionalneeds { get; set; }
    }
}
