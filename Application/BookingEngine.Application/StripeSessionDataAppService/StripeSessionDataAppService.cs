using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookingEngine.Application.StripeSessionDataAppService.Dtos;
using BookingEngine.Application.StripeSessionDataAppService.validation;
using BookingEngine.Data.DbContext;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;

namespace BookingEngine.Application.StripeSessionDataAppService
{
    public class StripeSessionDataAppService : BaseAppService<BookingEngineDbContext, Domain.Models.StripeSessionData, StripeSessionDataGetDto, StripeSessionDataGetDto, StripeSessionDataCreateDto, StripeSessionDataUpdateDto, SieveModel>, IStripeSessionDataAppService
    {
        public StripeSessionDataAppService(BookingEngineDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, StripeSessionValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
        }

        protected override IQueryable<Domain.Models.StripeSessionData> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input);
        }

    }
}
