using BillingItemsGenerator.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(BillingItemsGenerator.Startup))]
namespace BillingItemsGenerator
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddTransient<IActivityListService, ActivityListService>();
            builder.Services.AddTransient<IBillingItemsService, BillingItemsService>();           
            builder.Services.AddTransient<IPriceListService, PriceListService>();
            builder.Services.AddTransient<IInvoiceService, InvoiceService>();
        }
    }
}
