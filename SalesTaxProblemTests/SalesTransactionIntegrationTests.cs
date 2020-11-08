using NUnit.Framework;
using SalesTaxProblem;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using ApprovalTests;
using ApprovalTests.Reporters;
using SalesTaxProblem.Domain.Models;
using SalesTaxProblem.Domain.Services;
using SalesTaxProblem.Domain.Services.Tests;
using SalesTaxProblem.Persistence.Constants;

namespace SalesTaxProblem.Tests
{
    [UseReporter(typeof(VisualStudioReporter))]
    [ApprovalTests.Namers.UseApprovalSubdirectory("ApprovalTestsFiles")]
    [TestFixture()]
    public class SalesTransactionIntegrationTests
    {
        [Test()]
        public void ToReceipt_SingleBook_SnapshotTest()
        {
            var transactionItems = new List<ITransactionItem>
            {
                MockUtil.CreateTransactionItem(1, "book", 12.49d, ProductType.Book, false),
            };
            var taxCalcService = MockUtil.CreateCalcService(10.0d, 5.0d, new[] {"Book"});
            var sut = new SalesTransaction(taxCalcService);

            var actual = sut.ToReceipt(transactionItems);

            Approvals.Verify(actual);
        }

        [Test()]
        public void ToReceipt_Input1_SnapshotTest()
        {
            var transactionItems = new List<ITransactionItem>
            {
                MockUtil.CreateTransactionItem(1, "book", 12.49d, ProductType.Book, false),
                MockUtil.CreateTransactionItem(1, "music CD", 14.99d, ProductType.Taxable, false),
                MockUtil.CreateTransactionItem(1, "chocolate bar", 0.85d, ProductType.Food, false),
            };
            var taxCalcService = MockUtil.CreateCalcService(10.0d, 5.0d, new[] { "Book", "Food" });
            var sut = new SalesTransaction(taxCalcService);

            var actual = sut.ToReceipt(transactionItems);

            Approvals.Verify(actual);
        }

        [Test()]
        public void ToReceipt_Input2_SnapshotTest()
        {
            var transactionItems = new List<ITransactionItem>
            {
                MockUtil.CreateTransactionItem(1, "box of chocolates", 10.00d, ProductType.Food, true),
                MockUtil.CreateTransactionItem(1, "bottle of perfume", 47.50d, ProductType.Taxable, true),
            };
            var taxCalcService = MockUtil.CreateCalcService(10.0d, 5.0d, new[] { "Food" });
            var sut = new SalesTransaction(taxCalcService);

            var actual = sut.ToReceipt(transactionItems);

            Approvals.Verify(actual);
        }

        [Test()]
        public void ToReceipt_Input3_SnapshotTest()
        {
            var transactionItems = new List<ITransactionItem>
            {
                MockUtil.CreateTransactionItem(1, "bottle of perfume", 27.99d, ProductType.Taxable, true),
                MockUtil.CreateTransactionItem(1, "bottle of perfume", 18.99d, ProductType.Taxable, false),
                MockUtil.CreateTransactionItem(1, "packet of headache pills", 9.75d, ProductType.Medical, false),
                MockUtil.CreateTransactionItem(1, "box of chocolates", 11.25d, ProductType.Food, true),
            };
            var taxCalcService = MockUtil.CreateCalcService(10.0d, 5.0d, new[] { "Medical", "Food" });
            var sut = new SalesTransaction(taxCalcService);

            var actual = sut.ToReceipt(transactionItems);

            Approvals.Verify(actual);
        }
    }
}