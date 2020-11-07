using System.Collections.Generic;

namespace SalesTaxProblem.Persistence.Constants
{
    public static class AssumedSettings
    {
        public static double FiveCents => 0.05;
        public static class Config
        {
            public static IEnumerable<string> TaxExemptProductTypeNames => new List<string>
            {
                "books",
                "food",
                "medical"
            };

            public static double TaxRate { get; }
            static Config()
            {
                //In a real application this would be read from a database or config file 
                TaxRate = 0.10;
            }
        }


    }
}