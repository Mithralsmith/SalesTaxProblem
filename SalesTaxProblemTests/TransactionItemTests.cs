using NUnit.Framework;
using SalesTaxProblem;
using System;
using System.Collections.Generic;
using System.Text;
using SalesTaxProblem.Domain.Models;
using Telerik.JustMock;

namespace SalesTaxProblem.Tests
{
    [TestFixture()]
    public class TransactionItemTests
    {

        [Test()]
        public void ToString_ReturnsProductAndImportedAndTaxExempt_Test()
        {

            var expected = "product at $price, imported: False, taxable: False";
            IProduct iProduct = Mock.Create<Product>();
            Mock.Arrange(() => iProduct.ToString()).Returns("product at $price");

            var sut = new TransactionItem() { ProductPurchased = iProduct, IsImported = false, IsTaxable = false };


            var actual = sut.ToString();

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}