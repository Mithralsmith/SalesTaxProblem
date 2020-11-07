using System.Collections.Generic;
using SalesTaxProblem.Domain.Models;

namespace SalesTaxProblem.Domain.Services
{
    public interface ITaxCalcService
    {
        double CalculateTaxes(IEnumerable<IProduct> products);
    }
}