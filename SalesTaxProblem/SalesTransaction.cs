using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalesTaxProblem.Domain.Models;
using SalesTaxProblem.Domain.Services;
using SalesTaxProblem.Extensions;

namespace SalesTaxProblem
{
    public class SalesTransaction
    {
        private ITaxCalcService _taxCalc;
        private IEnumerable<IProduct> _products;
        public ICollection<ITransactionItem> ItemsSold { get; set; }

        public SalesTransaction(IEnumerable<IProduct> products, ITaxCalcService taxCalc)
        {
            _taxCalc = taxCalc;
            _products = products;
        }

        public double CalculateTaxes()
        {
            return _taxCalc.CalculateTaxes(ItemsSold);
        }

        public double CalculateTotalSale()
        {
            var totalOfPrices = _products.Select(p => p.Price).Sum();
            return totalOfPrices + CalculateTaxes();
        }
        
    }
}
