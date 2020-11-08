using NUnit.Framework;
using SalesTaxProblem.Domain.Models;
using Telerik.JustMock;

namespace SalesTaxProblemTests.Domain.Models
{
    [TestFixture()]
    public class TransactionItemTests
    {

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