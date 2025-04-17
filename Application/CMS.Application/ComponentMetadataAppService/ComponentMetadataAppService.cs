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
using CMS.Application.ComponentMetadataAppService.Dto;
using CMS.Application.ComponentMetadataAppService.Validations;

namespace CMS.Application.ComponentMetadataAppService
{
    public class ComponentMetadataAppService : BaseAppService<CMSDbContext, Domain.Models.ComponentMetadata, ComponentMetadataGetDto, ComponentMetadataGetDto, ComponentMetadataCreateDto, ComponentMetadataUpdateDto, SieveModel>, IComponentMetadataAppService
    {
        IHttpContextAccessor _httpContextAccessor;
        CMSDbContext _serviceDbContext;
        public ComponentMetadataAppService(CMSDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, ComponentMetadataValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _serviceDbContext = serviceDbContext;
        }

        protected override IQueryable<Domain.Models.ComponentMetadata> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input);
        }
    }
}
