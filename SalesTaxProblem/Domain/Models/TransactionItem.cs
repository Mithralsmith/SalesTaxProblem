namespace SalesTaxProblem.Domain.Models
{
    public class TransactionItem : ITransactionItem
    {
        public IProduct ProductPurchased { get; set; }
        public bool IsImported { get; set; }
        public bool IsTaxable { get; set; }

        public override string ToString()
        {
            return $"{ProductPurchased}, imported: {IsImported}, taxable: {IsTaxable}";
        }
    }
}
