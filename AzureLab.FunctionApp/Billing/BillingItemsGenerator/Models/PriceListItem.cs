using System;

namespace BillingItemsGenerator.Models
{
    public class PriceListItem
    {
        public string ProductCode { get; set; }
        public decimal Price { get; set; }

        public bool Matches(Beneficiary beneficiary) =>
           beneficiary.ProductCode == this.ProductCode;           
    }
}
