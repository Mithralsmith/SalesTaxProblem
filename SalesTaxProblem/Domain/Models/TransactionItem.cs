namespace SalesTaxProblem.Domain.Models
{
    public class TransactionItem : ITransactionItem
    {
        public IProduct ProductPurchased { get; set; }
        public double Quantity { get; set; }

        public override string ToString()
        {
            return $"{Quantity} {ProductPurchased}";
        }
    }
}
