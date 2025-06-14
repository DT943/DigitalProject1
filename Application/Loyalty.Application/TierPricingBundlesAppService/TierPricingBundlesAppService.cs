using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Application.Exceptions;
using Infrastructure.Application;
using Loyalty.Application.TierDetailsAppService.Dto;
using Loyalty.Application.TierDetailsAppService.Validations;
using Loyalty.Application.TierDetailsAppService;
using Loyalty.Data.DbContext;
using Loyalty.Domain.Models;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;
using Loyalty.Application.TierPricingBundlesAppService.Dtos;

namespace Loyalty.Application.TierPricingBundlesAppService
{
    public class TierPricingBundlesAppService : BaseAppService<LoyaltyDbContext, Domain.Models.TierPricingBundles, TierPricingBundlesGetDto, TierPricingBundlesGetDto, TierPricingBundlesCreateDto, TierPricingBundlesUpdateDto, SieveModel>, ITierPricingBundlesAppService
    {
        public TierPricingBundlesAppService(LoyaltyDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, TierDetailsValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
        }
    }
}