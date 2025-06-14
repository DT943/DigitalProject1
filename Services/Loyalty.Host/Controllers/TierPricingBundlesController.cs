using Infrastructure.Service.Controllers;
using Loyalty.Application.TierDetailsAppService.Dto;
using Loyalty.Application.TierDetailsAppService;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using Loyalty.Application.TierPricingBundlesAppService;
using Loyalty.Application.TierPricingBundlesAppService.Dtos;

namespace Loyalty.Host.Controllers
{
    public class TierPricingBundlesController : BaseController<ITierPricingBundlesAppService, Domain.Models.TierPricingBundles, TierPricingBundlesGetDto, TierPricingBundlesGetDto, TierPricingBundlesCreateDto, TierPricingBundlesUpdateDto, SieveModel>
    {
        public TierPricingBundlesController(ITierPricingBundlesAppService appService) : base(appService, Servics.Loyalty)
        {

        }

    }
}
