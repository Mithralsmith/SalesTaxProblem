namespace SalesTaxProblem.Domain.Models
{
    public interface ITransactionItem
    {
        IProduct ProductPurchased { get; set; }
        bool IsImported { get; set; }
        bool IsTaxable { get; set; }
    }
}