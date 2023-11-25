using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingItemsGenerator.Models
{
    public class Beneficiary
    {
        public string Name { get; }
        public string NationalId { get; }      
        public string ProductCode { get; }
        public Beneficiary(string nationalId, string name, string productCode)
        {
            Name = name;
            NationalId = nationalId;            
            ProductCode = productCode;
        }
        public static Beneficiary FromCsvLine(string csvLine)
        {
            string[] parts = csvLine.Split(new char[] { ';' });
            return new Beneficiary(parts[0], parts[1], parts[2]);
        }
    }
}
