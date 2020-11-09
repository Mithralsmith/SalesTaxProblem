using System;
using NUnit.Framework;
using SalesTaxProblem.Domain.Models;
using Telerik.JustMock;

namespace SalesTaxProblem.Domain.Models.Tests
{
    public class TransactionItemTests
    {
        [Test()]
        public void QuantityProperty_Throws_ArgumentException_IfAssignedANegativeValue_Test()
        {
            IProduct iProduct = Mock.Create<Product>();
            var sut = new TransactionItem() { ProductPurchased = iProduct, Quantity = 1 };


            Assert.Throws<ArgumentException>(() => sut.Quantity = -1);
        }

        [Test()]
        public void ToString_ReturnsProductAndImportedAndTaxExempt_Test()
        {

            var expected = "1 product at $price";
            IProduct iProduct = Mock.Create<Product>();
            Mock.Arrange(() => iProduct.ToString()).Returns("product at $price");

            var sut = new TransactionItem() { ProductPurchased = iProduct, Quantity = 1};


            var actual = sut.ToString();

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}