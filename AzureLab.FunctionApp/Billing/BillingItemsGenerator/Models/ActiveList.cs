namespace BillingItemsGenerator.Models
{
    public class ActiveList
    {
        public string CustomerCode { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public string[] DataLines { get; set; }
    }
}
