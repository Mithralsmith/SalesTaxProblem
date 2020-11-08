using System.Collections.Generic;
using System.Linq;
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

        public static ITransactionItem CreateTransactionItem(int quantity, string name, double price, ProductType prodType, bool isImported)
        {
            var product = new Product() {Name = name, IsImported = isImported, Price = price};
                product.SetProductType(prodType);
            return new TransactionItem() {ProductPurchased = product, Quantity = quantity};
        }


        public static ITaxExemptDiscriminatorService MockDiscriminatorService(IEnumerable<string> taxExemptProductTypeNames)
        {
            var mockDiscriminatorService = Mock.Create<ITaxExemptDiscriminatorService>();
            var names = taxExemptProductTypeNames.ToList();
            foreach (var name in names)
            {
                Mock.Arrange(() => mockDiscriminatorService.IsTaxable(Arg.IsAny<IProduct>()))
                    .Returns((IProduct p) =>
                    {
                        return false == names.Any(s => s.ToLower() == p.ProdType.ToLower());
                    });
            }

            return mockDiscriminatorService;

        }
        public static ITaxCalcService CreateCalcService(double taxRate, double importDutyRate, IEnumerable<string> taxExemptProductTypeNames)
        {
            var exemptDiscriminatorService = new TaxExemptDiscriminatorService(taxExemptProductTypeNames);
            var taxCalcService = new TaxCalcService(taxRate, importDutyRate, exemptDiscriminatorService);
            return taxCalcService;
        }
    }
}