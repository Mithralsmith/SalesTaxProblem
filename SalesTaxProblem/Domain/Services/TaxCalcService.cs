using System.Collections.Generic;
using SalesTaxProblem.Domain.Models;
using SalesTaxProblem.Extensions;

namespace SalesTaxProblem.Domain.Services
{
    public class TaxCalcService : ITaxCalcService
    {
        private ITaxExemptDiscriminatorService _exemptDiscriminatorService;
        private double _taxRate;

        public TaxCalcService(double taxRate, ITaxExemptDiscriminatorService exemptDiscriminatorService)
        {
            _taxRate = taxRate;
            _exemptDiscriminatorService = exemptDiscriminatorService;
        }

        public virtual double CalculateTax(IProduct product)
        {
            var tax = 0;
            if (_exemptDiscriminatorService.IsTaxExempt(product))
                return 0;
            else
            {
                
            }

            return tax;
        }

        public double CalculateTaxes(IEnumerable<IProduct> products)
        {
            return 0.0;
        }
        
    }

}