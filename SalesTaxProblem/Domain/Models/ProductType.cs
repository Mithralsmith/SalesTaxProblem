using Microsoft.VisualBasic;
using SalesTaxProblem.Persistence.Constants;

namespace SalesTaxProblem.Domain.Models
{
    public enum ProductType
    {
        Taxable = TaxConstants.DefaultInt, 
        Book,
        Food,
        Medical
    }
}