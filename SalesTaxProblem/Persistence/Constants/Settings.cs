using System.Collections.Generic;

namespace SalesTaxProblem.Persistence.Constants
{
    //This class provides values that depending on the real world application
    //  would come from a database, a config file, or constants class.
    public static class Settings
    {
        public static class Config
        {
            public static IEnumerable<string> TaxExemptProductTypeNames => new List<string>
            {
                "Book",
                "Food",
                "Medical"
            };

            public static double TaxRate { get; }
            public static double ImportDutyRate { get; }
            static Config()
            {
                TaxRate = 10;
                ImportDutyRate = 5;
            }
        }


    }
}