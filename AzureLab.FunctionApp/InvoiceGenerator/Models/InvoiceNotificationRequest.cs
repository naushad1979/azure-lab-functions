using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceGenerator.Models
{
    public class InvoiceNotificationRequest
    {
        public Invoice InvoiceForNotification { get; set; }
    }
}
