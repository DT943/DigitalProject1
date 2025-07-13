using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookingEngine.Application.OTAUserAppService.Dtos;
using BookingEngine.Application.OTAUserAppService.Validations;
using BookingEngine.Application.OTAUserAppService;
using BookingEngine.Data.DbContext;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;
using BookingEngine.Application.ExchangeCurrencyAppService.Dtos;
using BookingEngine.Application.ExchangeCurrencyAppService.Validations;
using Microsoft.EntityFrameworkCore;

namespace BookingEngine.Application.ExchangeCurrencyAppService
{
    public class ExchangeCurrencyAppService : BaseAppService<BookingEngineDbContext, Domain.Models.ExchangeRate, ExchangeRateGetDto, ExchangeRateGetDto, ExchangeRateCreateDto, ExchangeRateUpdateDto, SieveModel>, IExchangeCurrencyAppService
    {

        public ExchangeCurrencyAppService(BookingEngineDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, ExchangeCurrencyValidator validations, IHttpContextAccessor httpContextAccessor, IEncryptionAppService encryptionAppService) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {

        }

        protected override IQueryable<Domain.Models.ExchangeRate> QueryExcuter(SieveModel input)
        {

            return base.QueryExcuter(input);
              
        }


    }
}