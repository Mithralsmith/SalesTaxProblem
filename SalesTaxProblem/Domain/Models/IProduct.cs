namespace SalesTaxProblem.Domain.Models
{
    public interface IProduct
    {
        string Name { get; set; }
        double Price { get; set; }
        string ProdType { get;}
        bool IsImported { get; set; }
    }
}