using BillingItemsGenerator.Models;
using System;
using System.IO;
using System.Linq;

namespace BillingItemsGenerator.Parsers
{
    public static class ActiveListParser
    {
        public static ActiveList Parse(string name, Stream activeListBlob)
        {
            using(StreamReader reader = new StreamReader(activeListBlob))
            {
                var dataLines = reader.ReadToEnd();
                var fileParts = name.Split(new char[] { '_' });

                return new ActiveList
                {
                    CustomerCode = fileParts[0],
                    Year = int.Parse(fileParts[1]),
                    Month = int.Parse(fileParts[2]),
                    DataLines = dataLines.Split(Environment.NewLine.ToCharArray()).Where(x => x != "").ToArray()
                };
            }
        }
    }
}
