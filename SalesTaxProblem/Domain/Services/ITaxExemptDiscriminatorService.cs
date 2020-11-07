using SalesTaxProblem.Domain.Models;

namespace SalesTaxProblem.Domain.Services
{
    public interface ITaxExemptDiscriminatorService
    {
        public bool IsTaxExempt(IProduct product);
    }
}