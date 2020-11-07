namespace SalesTaxProblem.Domain.Models
{
    public interface IProduct
    {
        string Name { get; set; }
        double Price { get; set; }
        bool IsImported { get; set; }
    }
}