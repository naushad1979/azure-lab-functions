using InvoiceGenerator.Models;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Shared.Models;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceGenerator
{
    public static class InvoiceGenerationTrigger
    {
        [FunctionName("InvoiceGenerationTrigger")]
        public static void Run([QueueTrigger("invoice-generation-request",Connection = "ActiveListStorage")] InvoiceGenerationRequest request,
              [Table("billingItems")] CloudTable billingItems,
              [Queue("invoice-print-request")] out InvoicePrintRequest printRequest,
              [Queue("invoice-notification-request")] out InvoiceNotificationRequest notificationRequest,
            ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {request}");
            printRequest = null;
            notificationRequest = null;
            var items = GetBillingItemsFromTable(billingItems, request);
        }

        static  List<BillingItem> GetBillingItemsFromTable(CloudTable billingItems, InvoiceGenerationRequest request)
        {
            TableQuery query = new TableQuery()
                .Where(
                    TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, $"{request.CustomerCode}-{request.Year}-{request.Month}")
                );

            var querySegment = billingItems.ExecuteQuerySegmented(query,null).ToList();
            var items = new List<BillingItem>();
            foreach (var item in querySegment)
            {
                //items.Add(item);
            }
            return items;
        }
    }
}
