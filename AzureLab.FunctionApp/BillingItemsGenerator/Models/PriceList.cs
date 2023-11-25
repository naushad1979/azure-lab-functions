using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingItemsGenerator.Models
{
    public class PriceList
    {
        public string CustomerCode { get; set; }
        public IList<PriceListItem> Prices { get; set; }

        public decimal GetPrice(Beneficiary beneficiary) =>
            Prices
                .Where(p => p.Matches(beneficiary))
                .Select(p => p.Price)
                .FirstOrDefault();
    }
}
