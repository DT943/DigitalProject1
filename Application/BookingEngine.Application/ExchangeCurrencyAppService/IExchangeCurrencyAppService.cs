using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.ExchangeCurrencyAppService.Dtos;
using BookingEngine.Application.OTAUserAppService.Dtos;
using Infrastructure.Application;
using Sieve.Models;

namespace BookingEngine.Application.ExchangeCurrencyAppService
{
    public interface IExchangeCurrencyAppService : IBaseAppService<ExchangeRateGetDto, ExchangeRateGetDto, ExchangeRateCreateDto, ExchangeRateUpdateDto, SieveModel>
    {

    }
}
