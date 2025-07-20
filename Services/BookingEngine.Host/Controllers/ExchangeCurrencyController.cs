using BookingEngine.Application.AirPortAppService.Dtos;
using BookingEngine.Application.AirPortAppService;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using BookingEngine.Application.ExchangeCurrencyAppService;
using BookingEngine.Application.ExchangeCurrencyAppService.Dtos;

namespace BookingEngine.Host.Controllers
{
    public class ExchangeCurrencyController : BaseController<IExchangeCurrencyAppService, Domain.Models.ExchangeRate, ExchangeRateGetDto, ExchangeRateGetDto, ExchangeRateCreateDto, ExchangeRateUpdateDto, SieveModel>
    {
        public ExchangeCurrencyController(IExchangeCurrencyAppService appService) : base(appService, Servics.BookingEngine)
        {

        }
    }
}


