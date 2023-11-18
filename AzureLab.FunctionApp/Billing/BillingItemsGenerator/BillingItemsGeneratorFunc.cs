using System.Collections.Generic;
using System.IO;
using System.Linq;
using BillingItemsGenerator.Models;
using BillingItemsGenerator.Parsers;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace BillingItemsGenerator
{
    public class BillingItemsGeneratorFunc
    {
        [FunctionName("BillingItemsGeneratorFunc")]
        public void Run([BlobTrigger("active-list-container/{name}", Connection = "ActiveListStorage")] Stream activeListBlob, string name,
            [Table("billingItems")] ICollector<BillingItem> billingItems,
            ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {activeListBlob.Length} Bytes");

            var activeList = ActiveListParser.Parse(name, activeListBlob);
            var priceList = GetPriceList(activeList.CustomerCode);
            var generator = new BillingItemsGenerator();
            foreach (var item in generator.Generate(activeList,priceList))
            {
                billingItems.Add(item);
            }
        }

        private PriceList GetPriceList(string customerCode)
        {
            var customerPriceList = GetMockItems().Where(cust => cust.CustomerCode == customerCode).Single();
            return customerPriceList;
        }

        private IList<PriceList> GetMockItems()
        {
            PriceList priceList0 = new PriceList();
            priceList0.CustomerCode = "DMC";
            priceList0.Prices =
             new List<PriceListItem>
            {
                new PriceListItem{ ProductCode = "A", Price = 65 },
                new PriceListItem{ ProductCode = "B", Price = 70 },
                new PriceListItem{ ProductCode = "C", Price = 165 },
                new PriceListItem{ ProductCode = "D", Price = 275 }
            };

            PriceList priceList1 = new PriceList();
            priceList1.CustomerCode = "CA";
            priceList1.Prices =
             new List<PriceListItem>
            {
                new PriceListItem{ ProductCode = "A", Price = 10},
                new PriceListItem{ ProductCode = "B", Price = 80 },
                new PriceListItem{ ProductCode = "C", Price = 365 },
                new PriceListItem{ ProductCode = "D", Price = 675 }
            };
             
            var priceLists = new List<PriceList>();
            priceLists.Add(priceList0);
            priceLists.Add(priceList1);

            return priceLists;
        }
    }
}
