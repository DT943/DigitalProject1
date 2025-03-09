using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CMS.Application.ComponentAppService.Dto;
using CMS.Data.DbContext;
using Infrastructure.Application;
using Sieve.Services;
using CMS.Application.PageAppService.Validations;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using CMS.Application.ComponentAppService.Validations;

namespace CMS.Application.ComponentAppService
{
    public class ComponentAppService : BaseAppService<CMSDbContext, Domain.Models.Component, ComponentGetDto, ComponentCreateDto, ComponentUpdateDto, SieveModel>, IComponentAppService
    {
        IHttpContextAccessor _httpContextAccessor;
        CMSDbContext _serviceDbContext;
        public ComponentAppService(CMSDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, ComponentValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _serviceDbContext = serviceDbContext;
        }

        protected override IQueryable<Domain.Models.Component> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input);
        }
    }
}
