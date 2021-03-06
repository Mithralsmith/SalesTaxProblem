﻿using NUnit.Framework;
using SalesTaxProblem.Domain.Services;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using SalesTaxProblem.Domain.Models;
using SalesTaxProblem.Persistence.Constants;
using SalesTaxProblem.Tests;
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
                MockUtil.MockTransaction(1, "book", 12.49d, ProductType.Book, false),
                MockUtil.MockTransaction(1, "music CD", 14.99d, ProductType.Taxable, false),
                MockUtil.MockTransaction(1, "chocolate bar", 0.85d, ProductType.Food, false),
            };
            var mockDiscriminatorService = MockUtil.MockDiscriminatorService(Settings.Config.TaxExemptProductTypeNames);
            var sut = new TaxCalcService(Settings.Config.TaxRate, Settings.Config.ImportDutyRate, mockDiscriminatorService);

            var actual = sut.CalculateTaxes(transactionItems);

            Assert.That(actual, Is.EqualTo(expected));

        }



        [Test()]
        public void CalculateTaxes_Input2_Test()
        {
            var expected = 7.65d;
            var transactionItems = new List<ITransactionItem>
            {
                MockUtil.MockTransaction(1, "box of chocolates", 10.00d, ProductType.Food, true), 
                MockUtil.MockTransaction(1, "bottle of perfume", 47.50d, ProductType.Taxable, true),
            };
            var mockDiscriminatorService = MockUtil.MockDiscriminatorService(Settings.Config.TaxExemptProductTypeNames);
            var sut = new TaxCalcService(Settings.Config.TaxRate, Settings.Config.ImportDutyRate, mockDiscriminatorService);

            var actual = sut.CalculateTaxes(transactionItems);

            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test()]
        public void CalculateTaxes_Input3_Test()
        {
            var expected = 6.70;
            var transactionItems = new List<ITransactionItem>
            {
                MockUtil.MockTransaction(1, "bottle of perfume", 27.99d, ProductType.Taxable, true),
                MockUtil.MockTransaction(1, "bottle of perfume", 18.99d, ProductType.Taxable, false),
                MockUtil.MockTransaction(1, "packet of headache pills", 9.70d, ProductType.Medical, false),
                MockUtil.MockTransaction(1, "box of imported chocolates", 11.25d, ProductType.Food, true),
            };
            var mockDiscriminatorService = MockUtil.MockDiscriminatorService(Settings.Config.TaxExemptProductTypeNames);
            var sut = new TaxCalcService(Settings.Config.TaxRate, Settings.Config.ImportDutyRate, mockDiscriminatorService);

            var actual = sut.CalculateTaxes(transactionItems);

            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test()]
        public void CalculateTaxes_Input1_Book_NoTax_Test()
        {
            var expected = 0.0d;
            var transactionItems = new List<ITransactionItem>
            {
                MockUtil.MockTransaction(1, "book", 12.49d, ProductType.Book, false),
            };
            var mockDiscriminatorService = MockUtil.MockDiscriminatorService(Settings.Config.TaxExemptProductTypeNames);
            var sut = new TaxCalcService(Settings.Config.TaxRate, Settings.Config.ImportDutyRate, mockDiscriminatorService);

            var actual = sut.CalculateTaxes(transactionItems);

            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test()]
        public void CalculateTaxes_Input1_CD_150Tax_Test()
        {
            var expected = 1.50d;
            var transactionItems = new List<ITransactionItem>
            {
                MockUtil.MockTransaction(1, "music CD", 14.99d, ProductType.Taxable, false),
            };
            var mockDiscriminatorService = MockUtil.MockDiscriminatorService(Settings.Config.TaxExemptProductTypeNames);
            var sut = new TaxCalcService(Settings.Config.TaxRate, Settings.Config.ImportDutyRate, mockDiscriminatorService);

            var actual = sut.CalculateTaxes(transactionItems);

            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test()]
        public void CalculateTaxes_Input1_Choc_NoTax_Test()
        {
            var expected = 0.00d;
            var transactionItems = new List<ITransactionItem>
            {
                MockUtil.MockTransaction(1, "chocolate bar", 0.85d, ProductType.Food, false),
            };
            var mockDiscriminatorService = MockUtil.MockDiscriminatorService(Settings.Config.TaxExemptProductTypeNames);
            var sut = new TaxCalcService(Settings.Config.TaxRate, Settings.Config.ImportDutyRate, mockDiscriminatorService);

            var actual = sut.CalculateTaxes(transactionItems);

            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test()]
        public void CalculateTaxes_Input_multiple_Choc_NoTax_Test()
        {
            var expected = 0.00d;
            var transactionItems = new List<ITransactionItem>
            {
                MockUtil.MockTransaction(10, "chocolate bar", 0.85d, ProductType.Food, false),
            };
            var mockDiscriminatorService = MockUtil.MockDiscriminatorService(Settings.Config.TaxExemptProductTypeNames);
            var sut = new TaxCalcService(Settings.Config.TaxRate, Settings.Config.ImportDutyRate, mockDiscriminatorService);

            var actual = sut.CalculateTaxes(transactionItems);

            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void CalculateTaxes_Input_multiple_CD_1500Tax_Test()
        {
            var expected = 15.00d;
            var transactionItems = new List<ITransactionItem>
            {
                MockUtil.MockTransaction(10, "music CD", 14.99d, ProductType.Taxable, false),
            };
            var mockDiscriminatorService = MockUtil.MockDiscriminatorService(Settings.Config.TaxExemptProductTypeNames);
            var sut = new TaxCalcService(Settings.Config.TaxRate, Settings.Config.ImportDutyRate, mockDiscriminatorService);

            var actual = sut.CalculateTaxes(transactionItems);

            Assert.That(actual, Is.EqualTo(expected));

        }
    }
}