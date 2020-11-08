using System.Collections.Generic;
using SalesTaxProblem.Domain.Models;
using SalesTaxProblem.Domain.Services;
using SalesTaxProblem.Persistence.Constants;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace SalesTaxProblem.Tests
{
    public static class MockUtil
    {
        public static ITransactionItem MockTransaction(int quantity, string name, double price, ProductType prodType, bool isImported)
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

        public static ITaxCalcService MockCalcService(double taxRate, double importDutyRate, IEnumerable<string> taxExemptProductTypeNames)
        {
            var exemptDiscriminatorService = new TaxExemptDiscriminatorService(taxExemptProductTypeNames);
            var taxCalcService = new TaxCalcService(taxRate, importDutyRate, exemptDiscriminatorService);
            return taxCalcService;
        }
    }
}