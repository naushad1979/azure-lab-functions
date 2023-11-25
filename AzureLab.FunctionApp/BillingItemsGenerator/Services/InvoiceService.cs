using BillingItemsGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingItemsGenerator.Services
{
    public interface IInvoiceService
    {
        public Invoice Generate(ActiveList activeList);
    }
    public class InvoiceService : IInvoiceService
    {
        public Invoice Generate(ActiveList activeList)
        {
            return new Invoice
            {
                CustomerCode = activeList.CustomerCode,
                Year = activeList.Year,
                Month = activeList.Month
            };
        }
    }
}
