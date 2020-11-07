using NUnit.Framework;
using SalesTaxProblem.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using SalesTaxProblem.Persistence.Constants;

namespace SalesTaxProblem.Extensions.Tests
{
    [TestFixture()]
    public class TaxCalcExtensionsTests
    {
        private static object[] _roundUpTo5CentsStartExpectedCases =
        {
            new object[] {TaxConstants.FiveCents, 0.05, 0.05},
            new object[] {TaxConstants.FiveCents, 0.05999, 0.10},
            new object[] {TaxConstants.FiveCents, 0.05001, 0.10},
            new object[] {TaxConstants.FiveCents, 0.0525, 0.10},
            new object[] {TaxConstants.FiveCents, 0.04999, 0.05},
            new object[] {TaxConstants.FiveCents, 0.00001, 0.05},
            new object[] {TaxConstants.FiveCents, 0.00, 0.00},
        };

        [Test, TestCaseSource(nameof(_roundUpTo5CentsStartExpectedCases))]
        public void RoundUpToNearest5Cents_Rounds_Test(double roundTo, double start, double expected)
        {

            var actual = start.RoundUpToNearest(roundTo);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}