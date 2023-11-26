using InvoiceGenerator.Models;
using Microsoft.Azure.Cosmos.Table;
using Shared.Models;
using System;
using System.Collections.Generic;

namespace InvoiceGenerator.Services
{
    public interface IInvoiceProcessingService
    {
        Invoice Generate(InvoiceGenerationRequest request, List<BillingItem> billingItems);
    }
    public class InvoiceProcessingService : IInvoiceProcessingService
    {
        public Invoice Generate(InvoiceGenerationRequest request, List<BillingItem> billingItems)
        {
            var i = Invoice.Create(request.CustomerCode, request.Year, request.Month);
            i.BillItems(billingItems);
            return i;
        }

        
    }
}
