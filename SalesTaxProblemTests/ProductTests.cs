using NUnit.Framework;
using SalesTaxProblem;
using System;
using System.Collections.Generic;
using System.Text;
using SalesTaxProblem.Domain.Models;

namespace SalesTaxProblem.Tests
{
    [TestFixture()]
    public class ProductTests
    {
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

            var sut = new Product() { Name = "book", Price = 12.49, IsImported = true};

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