using BillingItemsGenerator.Models;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingItemsGenerator.Services
{
    public interface IInvoiceService
    {
        public InvoiceGenerationRequest Generate(ActiveList activeList);
    }
    public class InvoiceService : IInvoiceService
    {
        public InvoiceGenerationRequest Generate(ActiveList activeList)
        {
            return new InvoiceGenerationRequest
            {
                CustomerCode = activeList.CustomerCode,
                Year = activeList.Year,
                Month = activeList.Month
            };
        }
    }
}
