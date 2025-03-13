using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Application.MessageBroker;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;
using Offer.Data.DbContext;
using Offer.Application.OfferAppService.Dtos;
using Offer.Application.OfferAppService.Validations;

namespace Offer.Application.OfferAppService
{
    public class OfferAppService : BaseAppService<OfferDbContext, Domain.Models.Offer, OfferGetDto, OfferGetDto, OfferCreateDto, OfferUpdateDto, SieveModel>, IOfferAppService
    {
        IHttpContextAccessor _httpContextAccessor;
        OfferDbContext _serviceDbContext;
        public OfferAppService(OfferDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, OfferValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _serviceDbContext = serviceDbContext;
        }

        protected override IQueryable<Domain.Models.Offer> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input);
        }
    }
}
