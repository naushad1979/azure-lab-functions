using Microsoft.WindowsAzure.Storage.Table;

namespace BillingItemsGenerator.Models
{
    public class BillingItem: TableEntity
    {
        public string Beneficiary { get; set; }
        public string ProductCode { get; set; }
        public double Amount { get; set; }
    }
}
