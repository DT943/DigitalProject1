using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Offer.Application.OfferAppService.Dtos;
using Offer.Application.OfferAppService.Validations;
using Offer.Application.OfferAppService;
using Offer.Data.DbContext;
using Sieve.Models;
using Sieve.Services;
using Offer.Application.FlightOfferAppService.Dtos;
using Offer.Application.FlightOfferAppService.Validations;

namespace Offer.Application.FlightOfferAppService
{
    public class FlightOfferAppService : BaseAppService<OfferDbContext, Domain.Models.FlightOffer, FlightOfferGetDto, FlightOfferGetDto, FlightOfferCreateDto, FlightOfferUpdateDto, SieveModel>, IFlightOfferAppService
    {
        IHttpContextAccessor _httpContextAccessor;
        OfferDbContext _serviceDbContext;
        public FlightOfferAppService(OfferDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, FlightOfferValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _serviceDbContext = serviceDbContext;
        }

        protected override IQueryable<Domain.Models.FlightOffer> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input);
        }
    }
}
