using System;
using System.Runtime.CompilerServices;
using SalesTaxProblem.Domain.Models;
using SalesTaxProblem.Persistence.Constants;

namespace SalesTaxProblem.Extensions
{
    public static class TaxCalcExtensions
    {
        public static double RoundUpToNearest(this double value, double roundTo)
        {
            if (roundTo == 0)
            {
                return value;
            }
            return Math.Ceiling(value / roundTo) * roundTo;
        }

    }
}