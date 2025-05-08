using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CMS.Application.ComponentAppService.Dto;
using CMS.Application.ComponentAppService.Validations;
using CMS.Application.ComponentAppService;
using CMS.Data.DbContext;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;
using CMS.Application.StaticComponentAppService.Dto;
using CMS.Application.StaticComponentAppService.Validations;

namespace CMS.Application.StaticComponentAppService
{
    public class StaticComponentAppService : BaseAppService<CMSDbContext, Domain.Models.StaticComponent, StaticComponentGetDto, StaticComponentGetDto, StaticComponentCreateDto, StaticComponentUpdateDto, SieveModel>, IStaticComponentAppService
    {
        IHttpContextAccessor _httpContextAccessor;
        CMSDbContext _serviceDbContext;
        public StaticComponentAppService(CMSDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, StaticComponentValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _serviceDbContext = serviceDbContext;
        }

        protected override IQueryable<Domain.Models.StaticComponent> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input);
        }
    }
}
