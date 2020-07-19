using System.Collections.Generic;
using api.DTOs;

namespace api.Interfaces
{
    public interface ICurrencyManager
    {
        string[] GetLiveCurrencies();
        ConvertedDto ConvertLiveCurrencies(string fromCode, string toCode, string fromAmount);
        ConvertedDto ConvertManualCurrencies(string fromCode, string toCode, string fromAmount, string rate);
    }
}