using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CMS.Application.PageAppService.Dtos;
using CMS.Application.PageAppService.Validations;
using CMS.Data.DbContext;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;

namespace CMS.Application.PageAppService
{
    public class PageAppService : BaseAppService<CMSDbContext, Domain.Models.Page, PageGetDto, PageCreateDto, PageUpdateDto, SieveModel>, IPageAppService
    {
        IHttpContextAccessor _httpContextAccessor;
        CMSDbContext _serviceDbContext;
        public PageAppService(CMSDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, PageValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _serviceDbContext = serviceDbContext;
        }

        protected override IQueryable<Domain.Models.Page> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input);
        }
    }
}
