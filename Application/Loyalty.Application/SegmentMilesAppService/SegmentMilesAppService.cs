using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Application;
using Loyalty.Application.MemberTravelAgentDetailsAppService.Dto;
using Loyalty.Application.MemberTravelAgentDetailsAppService.Validations;
using Loyalty.Application.MemberTravelAgentDetailsAppService;
using Loyalty.Data.DbContext;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;
using Loyalty.Application.SegmentMilesAppService.Dto;
using Loyalty.Application.SegmentMilesAppService.Validations;

namespace Loyalty.Application.SegmentMilesAppService
{
    public class SegmentMilesAppService : BaseAppService<LoyaltyDbContext, Domain.Models.SegmentMiles, SegmentMilesGetDto, SegmentMilesGetDto, SegmentMilesCreateDto, SegmentMilesUpdateDto, SieveModel>, ISegmentMilesAppService
    {
        public SegmentMilesAppService(LoyaltyDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, SegmentMilesValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
        }
    }
}
