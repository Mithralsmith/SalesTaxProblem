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

        public SalesTransaction(ITaxCalcService taxCalc)
        {
            _taxCalc = taxCalc;
        }


        private double CalcTotalWithoutTaxes(IEnumerable<ITransactionItem> itemsSold)
        {
            return itemsSold.Select(i => i.ProductPurchased.Price).Sum();
        }


        public string ToReceipt(IEnumerable<ITransactionItem> itemsSold)
        {
            var receiptBuilder = new StringBuilder();

            var totalTax = 0.0d;
            var total = 0.0d;
            var items = itemsSold.ToList();

            foreach (var lineItem in items)
            {
                var prod = lineItem.ProductPurchased;
                var lineItemTotalPrice = prod.Price * lineItem.Quantity;
                var lineItemTax = _taxCalc.CalculateTaxes(new[] {lineItem});
                var priceWithTax = lineItemTotalPrice + lineItemTax;
                totalTax += lineItemTax;
                total += priceWithTax;
                var outLine =
                    $"  * {lineItem.Quantity} {(prod.IsImported ? "imported " : string.Empty)}{prod.Name}: {priceWithTax:F2}";
                receiptBuilder.AppendLine(outLine);
            }

            receiptBuilder.AppendLine($"  * Sales Taxes: {totalTax:F2} Total: {total:F2}");

            return receiptBuilder.ToString();

        }
        
    }
}
