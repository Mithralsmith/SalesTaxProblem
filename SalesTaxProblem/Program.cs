using System;
using System.Collections.Generic;
using System.Threading;
using SalesTaxProblem.Domain.Models;
using SalesTaxProblem.Domain.Services;
using SalesTaxProblem.Persistence.Constants;

namespace SalesTaxProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            var exemptDiscriminatorService = new TaxExemptDiscriminatorService(Settings.Config.TaxExemptProductTypeNames);
            var taxCalcService = new TaxCalcService(Settings.Config.TaxRate, Settings.Config.ImportDutyRate, exemptDiscriminatorService);
            var salesTransaction = new SalesTransaction(taxCalcService);

            Console.WriteLine("Problem: Sales Taxes");
            Console.WriteLine();

            var input = GetInput1Items1();
            WriteReceiptToConsole(input, salesTransaction, 1);

            input = GetInput1Items2();
            WriteReceiptToConsole(input, salesTransaction, 2);

            input = GetInput1Items3();
            WriteReceiptToConsole(input, salesTransaction, 3);
        }

        private static void WriteReceiptToConsole(IEnumerable<ITransactionItem> input, SalesTransaction salesTransaction, int sequence)
        {
            Console.WriteLine($"Input {sequence}:");
            foreach (var transactionItem in input)
            {
                Console.WriteLine($"  * {transactionItem}");
            }

            Console.WriteLine();

            var receipt = salesTransaction.ToReceipt(input);
            Console.WriteLine($"Output {sequence}");
            Console.WriteLine(receipt);
            Console.WriteLine();
        }

        private static IEnumerable<ITransactionItem> GetInput1Items1()
        {
            var item1 = new Product() { Name = "book", Price = 12.49d };
                item1.SetProductType(ProductType.Book);
            var item2 = new Product() { Name = "music CD", Price = 14.99d };
            var item3 = new Product() {Name = "chocolate bar", Price = 0.85d};
                item3.SetProductType(ProductType.Food);

            var transactionItems = new List<ITransactionItem>
            {
                new TransactionItem(){Quantity = 1, ProductPurchased = item1},
                new TransactionItem(){Quantity = 1, ProductPurchased = item2},
                new TransactionItem(){Quantity = 1, ProductPurchased = item3},
            };

            return transactionItems;
        }
        private static IEnumerable<ITransactionItem> GetInput1Items2()
        {
            var item1 = new Product() { Name = "box of chocolates", Price = 10.00d, IsImported = true};
                item1.SetProductType(ProductType.Food);
            var item2 = new Product() { Name = "bottle of perfume", Price = 47.50d, IsImported = true };

            var transactionItems = new List<ITransactionItem>
            {
                new TransactionItem(){Quantity = 1, ProductPurchased = item1},
                new TransactionItem(){Quantity = 1, ProductPurchased = item2},
            };

            return transactionItems;
        }

        private static IEnumerable<ITransactionItem> GetInput1Items3()
        {
            var item1 = new Product() { Name = "bottle of perfume", Price = 27.99d, IsImported = true };
            var item2 = new Product() { Name = "bottle of perfume", Price = 18.99d};
            var item3 = new Product() { Name = "packet of headache pills", Price = 9.75d };
                item3.SetProductType(ProductType.Medical);
            var item4 = new Product() { Name = "box of chocolates", Price = 11.25d, IsImported = true };
                item4.SetProductType(ProductType.Food);

            var transactionItems = new List<ITransactionItem>
            {
                new TransactionItem(){Quantity = 1, ProductPurchased = item1},
                new TransactionItem(){Quantity = 1, ProductPurchased = item2},
                new TransactionItem(){Quantity = 1, ProductPurchased = item3},
                new TransactionItem(){Quantity = 1, ProductPurchased = item4},
            };

            return transactionItems;
        }
    }
}
