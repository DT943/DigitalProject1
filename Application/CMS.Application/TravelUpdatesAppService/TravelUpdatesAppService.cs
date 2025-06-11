using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CMS.Application.StaticComponentAppService.Dto;
using CMS.Application.StaticComponentAppService.Validations;
using CMS.Application.StaticComponentAppService;
using CMS.Data.DbContext;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;
using CMS.Application.TravelUpdatesAppService.Dto;
using CMS.Application.TravelUpdatesAppService.Validations;

namespace CMS.Application.TravelUpdatesAppService
{
    public class TravelUpdatesAppService : BaseAppService<CMSDbContext, Domain.Models.TravelUpdates, TravelUpdatesGetDto, TravelUpdatesGetDto, TravelUpdatesCreateDto, TravelUpdatesUpdateDto, SieveModel>, ITravelUpdatesAppService
    {
        IHttpContextAccessor _httpContextAccessor;
        CMSDbContext _serviceDbContext;
        public TravelUpdatesAppService(CMSDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, TravelUpdatesValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _serviceDbContext = serviceDbContext;
        }

        protected override IQueryable<Domain.Models.TravelUpdates> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input);
        }
    }
}
