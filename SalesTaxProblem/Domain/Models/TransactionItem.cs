using System;

namespace SalesTaxProblem.Domain.Models
{
    public class TransactionItem : ITransactionItem
    {
        public IProduct ProductPurchased { get; set; }
        private int _quantity;

        public int Quantity
        {
            get => _quantity;
            set
            {
                if (value < 0)
                    throw new ArgumentException($"The quantity cannot be negative.",nameof(value));
                _quantity = value;
            }
        }

        public override string ToString()
        {
            return $"{Quantity} {ProductPurchased}";
        }
    }
}
