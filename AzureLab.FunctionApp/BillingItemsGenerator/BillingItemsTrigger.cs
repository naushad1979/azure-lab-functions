using System.IO;
using BillingItemsGenerator.Models;
using BillingItemsGenerator.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Shared.Models;

namespace BillingItemsGenerator
{
    public class BillingItemsTrigger
    {
        private readonly IActivityListService _activityListService;
        private readonly IPriceListService _priceListService;
        private readonly IBillingItemsService _billingItemsService;
        private readonly IInvoiceService _invoiceService;
        private readonly ILogger<BillingItemsTrigger> _logger;
        public BillingItemsTrigger(IActivityListService activityListService, 
            IPriceListService priceListService, IBillingItemsService billingItemsService,IInvoiceService invoiceService     
            , ILogger<BillingItemsTrigger> logger)
        {
            _activityListService = activityListService;
            _priceListService = priceListService;
            _billingItemsService = billingItemsService;
            _invoiceService = invoiceService;
            _logger = logger;            
        }

        [FunctionName("BillingItemsBlobTrigger")]
        public void Run([BlobTrigger("active-list-container/{name}", Connection = "ActiveListStorage")] Stream activeListBlob, string name,
            [Table("billingItems")] ICollector<BillingItem> billingItems, 
            [Queue("invoice-generation-request")] out InvoiceGenerationRequest invoiceRequest)
        {
            _logger.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {activeListBlob.Length} Bytes");

            var activeList = _activityListService.Parse(name, activeListBlob);
            var priceList = _priceListService.GetPriceList(activeList.CustomerCode);
            foreach (var item in _billingItemsService.Generate(activeList,priceList))
            {
                billingItems.Add(item);
            }

            invoiceRequest = _invoiceService.Generate(activeList);
        }       
    }
}
