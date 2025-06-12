using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application;
using Loyalty.Application.TierDetailsAppService.Dto;
using Loyalty.Application.TierPricingBundlesAppService.Dtos;
using Sieve.Models;

namespace Loyalty.Application.TierPricingBundlesAppService
{
    public interface ITierPricingBundlesAppService : IBaseAppService<TierPricingBundlesGetDto, TierPricingBundlesGetDto, TierPricingBundlesCreateDto, TierPricingBundlesUpdateDto, SieveModel>
    {

    }
}