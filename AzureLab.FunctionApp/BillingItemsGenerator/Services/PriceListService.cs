using BillingItemsGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingItemsGenerator.Services
{
    public interface IPriceListService
    {
        PriceList GetPriceList(string customerCode);
    }
    public class PriceListService : IPriceListService
    {
        public PriceList GetPriceList(string customerCode)
        {
            return GetPriceList().Where(cust => cust.CustomerCode == customerCode).Single();           
        }

        private IList<PriceList> GetPriceList()
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
