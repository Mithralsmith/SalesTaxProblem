using NUnit.Framework;
using SalesTaxProblem.Domain.Models;

namespace SalesTaxProblem.Domain.Models.Tests
{
    [TestFixture()]
    public class ProductTests
    {
        private static object[] _productTypeEnumToStringCases =
        {
            new object[] {ProductType.Book, "Book"},
            new object[] {ProductType.Taxable, "Taxable"},
            new object[] {ProductType.Medical, "Medical"},
            new object[] {ProductType.Food, "Food"},

        };

        [Test()]
        public void SetProductType_IfNotSet_Returns_TaxableString_Test()
        {
            var expected = "Taxable";
            var sut = new Product() { Name = "book", Price = 12.49 };


            Assert.That(sut.ProdType, Is.EqualTo(expected));
        }

        [Test, TestCaseSource(nameof(_productTypeEnumToStringCases))]
        public void SetProductType_Test(ProductType @enum, string expected)
        {
            var sut = new Product() { Name = "book", Price = 12.49 };

            sut.SetProductType(@enum);

            Assert.That(sut.ProdType, Is.EqualTo(expected));
        }


        [Test()]
        public void ToString_returns_NameAtPrice_Test()
        {
            var expected = "book at $12.49";
            var sut = new Product() { Name = "book", Price = 12.49 };

            var actual = sut.ToString();

            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test()]
        public void ToString_returns_ImportedPlusNameAtPrice_Test()
        {
            var expected = "imported book at $12.49";
            var sut = new Product() { Name = "book", Price = 12.49, IsImported = true };

            var actual = sut.ToString();

            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test()]
        public void ToString_returns_NameAtPrice_AddsTrailingZeros_Test()
        {
            var expected = "book at $12.40";
            var sut = new Product() { Name = "book", Price = 12.4 };

            var actual = sut.ToString();

            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test()]
        public void ToString_returns_NameAtPrice_UsingDefaultRoundingDownAt2DecimalPlaces_Test()
        {
            var expected = "book at $12.49";
            var sut = new Product() { Name = "book", Price = 12.495 };

            var actual = sut.ToString();

            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test()]
        public void ToString_returns_NameAtPrice_UsingDefaultRoundingUpAt2DecimalPlaces_Test()
        {
            var expected = "book at $12.50";
            var sut = new Product() { Name = "book", Price = 12.496 };

            var actual = sut.ToString();

            Assert.That(actual, Is.EqualTo(expected));

        }


    }
}