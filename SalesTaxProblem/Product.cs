using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxProblem
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"{Name} at {Price:C}";
        }
    }
}
