using System;
using System.Runtime.CompilerServices;

namespace SalesTaxProblem.Extensions
{
    public static class TaxCalcExtensions
    {
        public static double RoundToNearest5Cents(this double value)
        {

            return Math.Round(value / 0.05, 0, MidpointRounding.AwayFromZero) * 0.05;
        }
    }
}