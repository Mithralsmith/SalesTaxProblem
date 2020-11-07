using System.Collections.Generic;
using SalesTaxProblem.Domain.Models;

namespace SalesTaxProblem.Extensions
{
    public interface ITaxCalcService
    {
        double CalculateTaxes(IEnumerable<IProduct> products);
    }
}