using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingItemsGenerator.Models
{
    public class Invoice
    {
        public string CustomerCode { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
    }
}
