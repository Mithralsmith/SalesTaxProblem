using NUnit.Framework;
using SalesTaxProblem.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using SalesTaxProblem.Domain.Models;
using SalesTaxProblem.Persistence.Constants;
using Telerik.JustMock;

namespace SalesTaxProblem.Domain.Services.Tests

{
    [TestFixture()]
    public class TaxExemptDiscriminatorServiceTests
    {
        private static object[] _productTypeToIsTaxableCases =
        {
            new object[] {ProductType.Food, true},
            new object[] {ProductType.Medical, true},
            new object[] {ProductType.Book, true},
            new object[] {ProductType.Taxable, false},
        };

        [Test, TestCaseSource(nameof(_productTypeToIsTaxableCases))]
        public void IsTaxExempt_ReturnsValueBasedOnDefinedTypeNames_Test(ProductType prodType,bool expected)
        {
            var iProduct = Mock.Create<IProduct>();
            var productTypeName = prodType.ToString();
            Mock.Arrange(() => iProduct.ProdType).Returns(productTypeName);

            var sut = new TaxExemptDiscriminatorService(Settings.Config.TaxExemptProductTypeNames);

            var actual = sut.IsTaxExempt(iProduct);

            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void IsTaxExempt_ReturnsTrue_WhenTypeNameIncludedInConstructor_Test()
        {
            var iProduct = Mock.Create<IProduct>();
            var productTypeName = "book";
            Mock.Arrange(() => iProduct.ProdType).Returns(productTypeName);
            IEnumerable<string> productTypeNames = new List<string>
            {
                productTypeName
            };

            var sut = new TaxExemptDiscriminatorService(productTypeNames);

            var actual = sut.IsTaxExempt(iProduct);
            
            Assert.That(actual, Is.True);
        }
        [Test()]
        public void IsTaxExempt_ReturnsTrue_When_DifferentCaseTypeName_IncludedInConstructor_Test()
        {
            var productTypeName = "book";
            var productTypeNameWithDifferentCase = "Book";
            var iProduct = Mock.Create<IProduct>();
            Mock.Arrange(() => iProduct.ProdType).Returns(productTypeName);
            IEnumerable<string> productTypeNames = new List<string>
            {
                productTypeNameWithDifferentCase
            };

            var sut = new TaxExemptDiscriminatorService(productTypeNames);

            var actual = sut.IsTaxExempt(iProduct);

            Assert.That(actual, Is.True);
        }
        [Test()]
        public void IsTaxExempt_ReturnsFalse_WhenTypeName_Not_IncludedInConstructor_Test()
        {
            var productTypeName = "book";
            var differentTypeName = "apple";
            var iProduct = Mock.Create<IProduct>();
            Mock.Arrange(() => iProduct.ProdType).Returns(differentTypeName);
            IEnumerable<string> productTypeNames = new List<string>
            {
                productTypeName
            };

            var sut = new TaxExemptDiscriminatorService(productTypeNames);

            var actual = sut.IsTaxExempt(iProduct);

            Assert.That(actual, Is.False);
        }


        [Test()]
        public void IsTaxExempt_ReturnsFalse_WhenTypeName_MisspelledInConstructor_Test()
        {
            var misspelledProductTypeName = "booke";
            var productTypeName = "book";
            var iProduct = Mock.Create<IProduct>();
            Mock.Arrange(() => iProduct.ProdType).Returns(productTypeName);
            IEnumerable<string> productTypeNames = new List<string>
            {
                misspelledProductTypeName
            };

            var sut = new TaxExemptDiscriminatorService(productTypeNames);

            var actual = sut.IsTaxExempt(iProduct);

            Assert.That(actual, Is.False);
        }
    }
}