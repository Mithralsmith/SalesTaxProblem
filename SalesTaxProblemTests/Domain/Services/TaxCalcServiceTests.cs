using NUnit.Framework;
using SalesTaxProblem.Domain.Services;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using SalesTaxProblem.Domain.Models;
using SalesTaxProblem.Persistence.Constants;
using Telerik.JustMock;

namespace SalesTaxProblem.Domain.Services.Tests
{
    [TestFixture()]
    public class TaxCalcServiceTests
    {
        [Test()]
        public void CalculateTaxes_Input1_Test()
        {
            var expected = 1.50d;
            var transactionItems = new List<ITransactionItem>
            {
                MockTransaction(1, "book", 12.49d, ProductType.Book, false),
                MockTransaction(1, "music CD", 14.99d, ProductType.Taxable, false),
                MockTransaction(1, "chocolate bar", 0.85d, ProductType.Food, false),
            };
            var taxExemptDiscriminator = new TaxExemptDiscriminatorService(Settings.Config.TaxExemptProductTypeNames);
            var sut = new TaxCalcService(Settings.Config.TaxRate, Settings.Config.ImportDutyRate, taxExemptDiscriminator);

            var actual = sut.CalculateTaxes(transactionItems);

            Assert.That(actual, Is.EqualTo(expected));

        }



        [Test()]
        public void CalculateTaxes_Input2_Test()
        {
            var expected = 7.65d;
            var transactionItems = new List<ITransactionItem>
            {
                MockTransaction(1, "box of chocolates", 10.00d, ProductType.Food, true),
                MockTransaction(1, "bottle of perfume", 47.50d, ProductType.Taxable, true),
            };
            var taxExemptDiscriminator = new TaxExemptDiscriminatorService(Settings.Config.TaxExemptProductTypeNames);
            var sut = new TaxCalcService(Settings.Config.TaxRate, Settings.Config.ImportDutyRate, taxExemptDiscriminator);

            var actual = sut.CalculateTaxes(transactionItems);

            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test()]
        public void CalculateTaxes_Input3_Test()
        {
            var expected = 6.70;
            var transactionItems = new List<ITransactionItem>
            {
                MockTransaction(1, "bottle of perfume", 27.99d, ProductType.Taxable, true),
                MockTransaction(1, "bottle of perfume", 18.99d, ProductType.Taxable, false),
                MockTransaction(1, "headache pills", 9.70d, ProductType.Medical, false),
                MockTransaction(1, "box of imported chocolates", 11.25d, ProductType.Food, true),
            };
            var taxExemptDiscriminator = new TaxExemptDiscriminatorService(Settings.Config.TaxExemptProductTypeNames);
            var sut = new TaxCalcService(Settings.Config.TaxRate, Settings.Config.ImportDutyRate, taxExemptDiscriminator);

            var actual = sut.CalculateTaxes(transactionItems);

            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test()]
        public void CalculateTaxes_Input1_Book_NoTax_Test()
        {
            var expected = 0.0d;
            var transactionItems = new List<ITransactionItem>
            {
                MockTransaction(1, "book", 12.49d, ProductType.Book, false),
            };
            var taxExemptDiscriminator = new TaxExemptDiscriminatorService(Settings.Config.TaxExemptProductTypeNames);
            var sut = new TaxCalcService(Settings.Config.TaxRate, Settings.Config.ImportDutyRate, taxExemptDiscriminator);

            var actual = sut.CalculateTaxes(transactionItems);

            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test()]
        public void CalculateTaxes_Input1_CD_150Tax_Test()
        {
            var expected = 1.50d;
            var transactionItems = new List<ITransactionItem>
            {
                MockTransaction(1, "music CD", 14.99d, ProductType.Taxable, false),
            };
            var taxExemptDiscriminator = new TaxExemptDiscriminatorService(Settings.Config.TaxExemptProductTypeNames);
            var sut = new TaxCalcService(Settings.Config.TaxRate, Settings.Config.ImportDutyRate, taxExemptDiscriminator);

            var actual = sut.CalculateTaxes(transactionItems);

            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test()]
        public void CalculateTaxes_Input1_Choc_NoTax_Test()
        {
            var expected = 0.00d;
            var transactionItems = new List<ITransactionItem>
            {
                MockTransaction(1, "chocolate bar", 0.85d, ProductType.Food, false),
            };
            var taxExemptDiscriminator = new TaxExemptDiscriminatorService(Settings.Config.TaxExemptProductTypeNames);
            var sut = new TaxCalcService(Settings.Config.TaxRate, Settings.Config.ImportDutyRate, taxExemptDiscriminator);

            var actual = sut.CalculateTaxes(transactionItems);

            Assert.That(actual, Is.EqualTo(expected));

        }
        private ITransactionItem MockTransaction(int quantity, string name, double price, ProductType prodType, bool isImported)
        {
            var product1 = Mock.Create<IProduct>();
            Mock.Arrange(() => product1.Name).Returns(name);
            Mock.Arrange(() => product1.Price).Returns(price);
            Mock.Arrange(() => product1.ProdType).Returns(prodType.ToString());
            Mock.Arrange(() => product1.IsImported).Returns(isImported);
            var item1 = Mock.Create<ITransactionItem>();
            Mock.Arrange(() => item1.ProductPurchased).Returns(product1);
            Mock.Arrange(() => item1.Quantity).Returns(quantity);
            return item1;
        }
    }
}