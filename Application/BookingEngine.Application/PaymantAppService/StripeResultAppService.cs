using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookingEngine.Application.PaymantAppService.Dtos;
using BookingEngine.Application.PaymantAppService.Validations;
using BookingEngine.Data.DbContext;
using BookingEngine.Domain.Models;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace BookingEngine.Application.PaymantAppService
{
    public class StripeResultAppService : BaseAppService<BookingEngineDbContext, Domain.Models.StripeResult, StripeResultGetDto, StripeResultGetDto, StripeResultCreateDto, StripeResultUpdateDto, SieveModel>, IStripeResultAppService
    {
        public StripeResultAppService(BookingEngineDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, StripeResultValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {

        }
        protected override IQueryable<Domain.Models.StripeResult> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input);

        }

    }

}
