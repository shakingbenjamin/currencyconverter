using System;

namespace api.Extensions
{
    public static class ConverterExtensions
    {
        public static decimal StringToDecimal(this string value)
        {
            return Convert.ToDecimal(value);
        }

        public static decimal DoubleToDecimal(this double value)
        {
            return Convert.ToDecimal(value);
        }
    }
}