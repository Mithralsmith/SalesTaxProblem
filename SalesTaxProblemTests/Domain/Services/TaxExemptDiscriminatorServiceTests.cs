using NUnit.Framework;
using SalesTaxProblem.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using SalesTaxProblem.Domain.Models;
using Telerik.JustMock;

namespace SalesTaxProblem.Domain.Services.Tests
{
    [TestFixture()]
    public class TaxExemptDiscriminatorServiceTests
    {
        [Test()]
        public void IsTaxExempt_ReturnsTrue_WhenNameIncludedInConstructor_Test()
        {
            var iProduct = Mock.Create<IProduct>();
            var productName = "book";
            Mock.Arrange(() => iProduct.Name).Returns(productName);
            IEnumerable<string> productNames = new List<string>
            {
                productName
            };

            var sut = new TaxExemptDiscriminatorService(productNames);

            var actual = sut.IsTaxExempt(iProduct);
            
            Assert.That(actual, Is.True);
        }
        [Test()]
        public void IsTaxExempt_ReturnsTrue_When_DifferentCaseName_IncludedInConstructor_Test()
        {
            var productName = "book";
            var productNameWithDifferentCase = "Book";
            var iProduct = Mock.Create<IProduct>();
            Mock.Arrange(() => iProduct.Name).Returns(productName);
            IEnumerable<string> productNames = new List<string>
            {
                productNameWithDifferentCase
            };

            var sut = new TaxExemptDiscriminatorService(productNames);

            var actual = sut.IsTaxExempt(iProduct);

            Assert.That(actual, Is.True);
        }
        [Test()]
        public void IsTaxExempt_ReturnsFalse_WhenName_Not_IncludedInConstructor_Test()
        {
            var productName = "book";
            var differentName = "apple";
            var iProduct = Mock.Create<IProduct>();
            Mock.Arrange(() => iProduct.Name).Returns(differentName);
            IEnumerable<string> productNames = new List<string>
            {
                productName
            };

            var sut = new TaxExemptDiscriminatorService(productNames);

            var actual = sut.IsTaxExempt(iProduct);

            Assert.That(actual, Is.False);
        }


        [Test()]
        public void IsTaxExempt_ReturnsFalse_WhenName_MisspelledInConstructor_Test()
        {
            var misspelledProductName = "booke";
            var productName = "book";
            var iProduct = Mock.Create<IProduct>();
            Mock.Arrange(() => iProduct.Name).Returns(productName);
            IEnumerable<string> productNames = new List<string>
            {
                misspelledProductName
            };

            var sut = new TaxExemptDiscriminatorService(productNames);

            var actual = sut.IsTaxExempt(iProduct);

            Assert.That(actual, Is.False);
        }
    }
}