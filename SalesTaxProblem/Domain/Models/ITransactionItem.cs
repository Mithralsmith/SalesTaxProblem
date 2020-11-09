namespace SalesTaxProblem.Domain.Models
{
    public interface ITransactionItem
    {
        IProduct ProductPurchased { get; set; }
        int Quantity { get; set; }

    }
}