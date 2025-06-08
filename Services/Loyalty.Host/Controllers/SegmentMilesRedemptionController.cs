using Infrastructure.Service.Controllers;
using Loyalty.Application.SegmentMilesAppService.Dto;
using Loyalty.Application.SegmentMilesAppService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using Loyalty.Application.SegmentMilesRedemption;
using Loyalty.Application.SegmentMilesRedemption.Dto;

namespace Loyalty.Host.Controllers
{
    public class SegmentMilesRedemptionController : BaseController<ISegmentMilesRedemptionAppService, Domain.Models.SegmentMilesRedemption, SegmentMilesRedemptionGetDto, SegmentMilesRedemptionGetDto, SegmentMilesRedemptionCreateDto, SegmentMilesRedemptionUpdateDto, SieveModel>
    {
        public SegmentMilesRedemptionController(ISegmentMilesRedemptionAppService appService) : base(appService, Servics.Loyalty)
        {

        }


         
        [HttpPost("BulkCreate")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<SegmentMilesRedemptionGetDto>> BulkCreate(List<SegmentMilesRedemptionCreateDto> dto)
        {
            if (!UserHasPermission("Admin", "Manager", "Supervisor", "Officer"))
            {
                return Forbid();
            }
            foreach (var item in dto)
            {
                var entity = await _appService.Create(item);
            }
            return Ok("Done");
        }

    }
}
