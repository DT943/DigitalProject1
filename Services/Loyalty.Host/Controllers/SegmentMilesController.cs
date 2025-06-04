using Infrastructure.Service.Controllers;
using Loyalty.Application.MemberAccrualTransactions.Dtos;
using Loyalty.Application.MemberAccrualTransactions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using Loyalty.Application.SegmentMilesAppService;
using Loyalty.Application.SegmentMilesAppService.Dto;

namespace Loyalty.Host.Controllers
{
    [Authorize]
    public class SegmentMilesController : BaseController<ISegmentMilesAppService, Domain.Models.SegmentMiles, SegmentMilesGetDto, SegmentMilesGetDto, SegmentMilesCreateDto, SegmentMilesUpdateDto, SieveModel>
    {
        public SegmentMilesController(ISegmentMilesAppService appService) : base(appService, Servics.Loyalty)
        {

        }



        [HttpPost("BulkCreate")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public  async Task<ActionResult<SegmentMilesGetDto>> BulkCreate(List<SegmentMilesCreateDto> dto)
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
