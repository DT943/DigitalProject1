using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Application;
using Loyalty.Application.SegmentMilesAppService.Dto;
using Loyalty.Application.SegmentMilesAppService.Validations;
using Loyalty.Application.SegmentMilesAppService;
using Loyalty.Data.DbContext;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;
using Loyalty.Application.SegmentMilesRedemption.Validations;
using Loyalty.Application.SegmentMilesRedemption.Dto;

namespace Loyalty.Application.SegmentMilesRedemption
{
    public class SegmentMilesRedemptionAppService : BaseAppService<LoyaltyDbContext, Domain.Models.SegmentMilesRedemption, SegmentMilesRedemptionGetDto, SegmentMilesRedemptionGetDto, SegmentMilesRedemptionCreateDto, SegmentMilesRedemptionUpdateDto, SieveModel>, ISegmentMilesRedemptionAppService
    {
        public SegmentMilesRedemptionAppService(LoyaltyDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, SegmentMilesRedemptionValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
        }
    }
}
