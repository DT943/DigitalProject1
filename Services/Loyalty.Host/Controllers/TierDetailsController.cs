using Infrastructure.Service.Controllers;
using Loyalty.Application.SegmentMilesAppService.Dto;
using Loyalty.Application.SegmentMilesAppService;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using Loyalty.Application.TierDetailsAppService;
using Loyalty.Application.TierDetailsAppService.Dto;
using Microsoft.AspNetCore.Authorization;

namespace Loyalty.Host.Controllers
{
    [Authorize]
    public class TierDetailsController : BaseController<ITierDetailsAppService, Domain.Models.TierDetails, TierDetailsGetDto, TierDetailsGetDto, TierDetailsCreateDto, TierDetailsUpdateDto, SieveModel>
    {
        public TierDetailsController(ITierDetailsAppService appService) : base(appService, Servics.Loyalty)
        {

        }
        
    }
}
