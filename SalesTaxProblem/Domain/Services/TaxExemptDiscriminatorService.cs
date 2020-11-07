using System;
using System.Collections.Generic;
using SalesTaxProblem.Domain.Models;

namespace SalesTaxProblem.Domain.Services
{
    public class TaxExemptDiscriminatorService : ITaxExemptDiscriminatorService
    {
        private readonly HashSet<string> _exemptProductNamesMap = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        public TaxExemptDiscriminatorService(IEnumerable<string> exemptProductNames)
        {
            _exemptProductNamesMap.UnionWith(exemptProductNames);
        }

        public bool IsTaxExempt(IProduct product)
        {
            return _exemptProductNamesMap.Contains(product.Name);
        }
    }
}