using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly ILogger<CurrencyController> _logger;
        private readonly ICurrencyManager _currencyManager;

        public CurrencyController(ILogger<CurrencyController> logger, ICurrencyManager currencyManager)
        {
            _logger = logger;
            _currencyManager = currencyManager;
        }

        [HttpGet]
        public string[] Get()
        {
            return _currencyManager.GetLiveCurrencies();
        }

        [HttpGet]
        [Route("GetLiveConversion")]
        public ConvertedDto GetLiveConversion([FromQuery]CurrencyParamsDto dto)
        {
            return _currencyManager.ConvertLiveCurrencies(dto.FromCode, dto.ToCode, dto.FromAmount);
        }

        [HttpGet]
        [Route("GetManualConversion")]
        public ConvertedDto GetManualConversion([FromQuery]CurrencyParamsDto dto)
        {
            return _currencyManager.ConvertManualCurrencies(dto.FromCode, dto.ToCode, dto.FromAmount, dto.Rate);
        }
    }
}
