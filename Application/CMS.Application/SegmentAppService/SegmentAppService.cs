using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CMS.Application.PageAppService.Dtos;
using CMS.Application.PageAppService.Validations;
using CMS.Application.PageAppService;
using CMS.Data.DbContext;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;
using CMS.Application.SegmentAppService.Dtos;
using CMS.Application.SegmentAppService.Validations;

namespace CMS.Application.SegmentAppService
{
    public class SegmentAppService : BaseAppService<CMSDbContext, Domain.Models.Segment, SegmentGetDto, SegmentCreateDto, SegmentUpdateDto, SieveModel>, ISegmentAppService
    {
        IHttpContextAccessor _httpContextAccessor;
        CMSDbContext _serviceDbContext;
        public SegmentAppService(CMSDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, SegmentValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _serviceDbContext = serviceDbContext;
        }

        protected override IQueryable<Domain.Models.Segment> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input);
        }
    }
}
