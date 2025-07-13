using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookingEngine.Application.OTAUserAppService.Dtos;
using BookingEngine.Domain.Models;

namespace BookingEngine.Application.ExchangeCurrencyAppService.Dtos
{
    public class ExchangeCurrencyInputMapperProfile : Profile
    {
        public ExchangeCurrencyInputMapperProfile() {


            CreateMap<Currency, CurrencyGetDto>();
            CreateMap<CurrencyCreateDto, Currency>();
            CreateMap<CurrencyUpdateDto, Currency>();


            CreateMap<ExchangeRate, ExchangeRateGetDto>();
            CreateMap<ExchangeRateCreateDto, ExchangeRate>();
            CreateMap<ExchangeRateUpdateDto, ExchangeRate>();

        }
    }
}
