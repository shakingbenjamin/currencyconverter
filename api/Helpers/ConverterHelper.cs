using System;

namespace api.Helpers
{
    public static class ConverterHelper
    {
        public static decimal CalculatExchangeRate(decimal rate, decimal value)
        {
            return Math.Round(rate * value, 2);
        }
    }
}