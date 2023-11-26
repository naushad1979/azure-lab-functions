
namespace Shared.Models
{
    public class InvoiceGenerationRequest
    {
        public string CustomerCode { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
    }
}
