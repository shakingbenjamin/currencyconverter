using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using api.Extensions;
using api.Helpers;
using api.DTOs;
using api.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace api.Models
{
    public class CurrencyManager : ICurrencyManager
    {
        private string url = "https://api.exchangeratesapi.io/latest?symbols=";
        public string[] GetLiveCurrencies()
        {
            string json;
            var uri = new Uri("https://openexchangerates.org/api/currencies.json");
            using (var client = new WebClient())
            {
                json = client.DownloadString(uri);
            }
            var obj = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            var codes = new List<string>();
            foreach(var c in obj.Keys)
            {
                codes.Add(c);
            }
            return codes.ToArray();
        }

        public ConvertedDto ConvertLiveCurrencies(string fromCode, string toCode, string fromAmount)
        {
            string result;
            var amount = fromAmount.StringToDecimal();
            var uri = new Uri($"{url}{fromCode},{toCode}");
            using (var client = new WebClient())
            {
                result = client.DownloadString(uri);
            } 
            var obj = JObject.Parse(result);
            var value = (obj["rates"] as JObject); 
            var rates = value.ToObject<Dictionary<string,string>>();
            var rate = rates[toCode].StringToDecimal();
            var exchange = ConverterHelper.CalculatExchangeRate(rate, amount);

            return new ConvertedDto{
                Result = exchange,
                Amount = amount,
                FromCode = fromCode,
                ToCode = toCode,
                Rate = rate
            };
        }

        public ConvertedDto ConvertManualCurrencies(string fromCode, string toCode, string fromAmount, string rate)
        {
            var exchange = ConverterHelper.CalculatExchangeRate(rate.StringToDecimal(), fromAmount.StringToDecimal());
            return new ConvertedDto{
                Result = exchange,
                Amount = fromAmount.StringToDecimal(),
                FromCode = fromCode,
                ToCode = toCode,
                Rate = rate.StringToDecimal()
            };
        }
    }
}