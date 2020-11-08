namespace SalesTaxProblem.Domain.Models
{
    public interface ITransactionItem
    {
        IProduct ProductPurchased { get; set; }
        double Quantity { get; set; }

    }
}