﻿using BillingItemsGenerator.Models;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BillingItemsGenerator.Services
{
    public interface IBillingItemsService
    {
        List<BillingItem> Generate(ActiveList activeList, PriceList priceList);
    }
    public class BillingItemsService: IBillingItemsService
    {
        public List<BillingItem> Generate(ActiveList activeList, PriceList priceList)
        {
            var billingItems = new List<BillingItem>();
            foreach (var line in activeList.DataLines)
            {
                var beneficiary = Beneficiary.FromCsvLine(line);
                var price = priceList.GetPrice(beneficiary);

                billingItems.Add(new BillingItem
                {
                    PartitionKey = $"{activeList.CustomerCode}-{activeList.Year}-{activeList.Month}",
                    RowKey = Guid.NewGuid().ToString(),
                    Timestamp = DateTime.Now,
                    Beneficiary = $"{beneficiary.NationalId} {beneficiary.Name}",
                    ProductCode = beneficiary.ProductCode,
                    Amount = Convert.ToDouble(price)
                });
            }

            return billingItems;
        }
    }
}
