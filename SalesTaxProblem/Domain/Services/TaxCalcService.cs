using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using SalesTaxProblem.Domain.Models;
using SalesTaxProblem.Extensions;
using SalesTaxProblem.Persistence.Constants;

namespace SalesTaxProblem.Domain.Services
{
    public class TaxCalcService : ITaxCalcService
    {
        private ITaxExemptDiscriminatorService _exemptDiscriminatorService;
        private double _taxRate;
        private double _importDutyRate;

        public TaxCalcService(double taxRate, double importDutyRate, ITaxExemptDiscriminatorService exemptDiscriminatorService)
        {
            _taxRate = taxRate;
            _importDutyRate = importDutyRate;
            _exemptDiscriminatorService = exemptDiscriminatorService;
        }

        protected virtual double CalculateTax(IProduct product, int quantity)
        {
            var dutyTax = CalculateDutyTax(product, quantity);
            var tax = CalculateSalesTax(product, quantity);

            return tax + dutyTax;
        }

        protected virtual double CalculateSalesTax(IProduct product, int quantity)
        {
            var tax = 0.0d;
            if (_exemptDiscriminatorService.IsTaxable(product))
            {
                tax = (quantity * _taxRate * product.Price / 100);
            }

            return tax;
        }

        protected virtual double CalculateDutyTax(IProduct product, int quantity)
        {
            var dutyTax = 0.0d;
            if (product.IsImported)
            {
                dutyTax = (quantity * _importDutyRate * product.Price / 100);
            }

            return dutyTax;
        }


        public double CalculateTaxes(IEnumerable<ITransactionItem> lineItems)
        {
            //Assumption calculate all the 
            var tax = 0.0d;
            foreach (var lineItem in lineItems)
            {
                tax += CalculateTax(lineItem.ProductPurchased, lineItem.Quantity);
            }

            return tax.RoundUpToNearest(TaxConstants.FiveCents);
        }
        
    }

}