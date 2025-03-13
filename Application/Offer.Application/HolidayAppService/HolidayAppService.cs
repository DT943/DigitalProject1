using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Offer.Application.HolidayAppService.Dtos;
using Offer.Application.HolidayAppService.Validations;
using Offer.Application.OfferAppService;
using Offer.Application.OfferAppService.Dtos;
using Offer.Application.OfferAppService.Validations;
using Offer.Data.DbContext;
using Sieve.Models;
using Sieve.Services;

namespace Offer.Application.HolidayAppService
{
    public class HolidayAppService : BaseAppService<OfferDbContext, Domain.Models.HolidayOffer, HolidayGetDto, HolidayGetDto, HolidayCreateDto, HolidayUpdateDto, SieveModel>, IHolidayAppService
    {
        IHttpContextAccessor _httpContextAccessor;
        OfferDbContext _serviceDbContext;
        public HolidayAppService(OfferDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, HolidayValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _serviceDbContext = serviceDbContext;
        }

        protected override IQueryable<Domain.Models.HolidayOffer> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input);
        }
    }
}
