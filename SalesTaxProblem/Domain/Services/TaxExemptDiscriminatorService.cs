using System;
using System.Collections.Generic;
using SalesTaxProblem.Domain.Models;

namespace SalesTaxProblem.Domain.Services
{
    public class TaxExemptDiscriminatorService : ITaxExemptDiscriminatorService
    {
        private readonly HashSet<string> _exemptProdTypeNamesMap = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        public TaxExemptDiscriminatorService(IEnumerable<string> exemptProdTypeNames)
        {
            _exemptProdTypeNamesMap.UnionWith(exemptProdTypeNames);
        }

        public bool IsTaxExempt(IProduct product)
        {
            return _exemptProdTypeNamesMap.Contains(product.ProdType);
        }
    }
}