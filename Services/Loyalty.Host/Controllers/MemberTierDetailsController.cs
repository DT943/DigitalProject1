using Infrastructure.Service.Controllers;
using Loyalty.Application.MemberTelephoneDetailsAppService.Dto;
using Loyalty.Application.MemberTelephoneDetailsAppService;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using Loyalty.Application.MemberTierDetailsAppService;
using Loyalty.Application.MemberTierDetailsAppService.Dto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Loyalty.Host.Controllers
{
    [Authorize]
    public class MemberTierDetailsController : BaseController<IMemberTierDetailsAppService, Domain.Models.MemberTierDetails, MemberTierDetailsGetDto, MemberTierDetailsGetDto, MemberTierDetailsCreateDto, MemberTierDetailsUpdateDto, SieveModel>
    {
        public MemberTierDetailsController(IMemberTierDetailsAppService appService) : base(appService, Servics.Loyalty)
        {
        }

        [HttpGet("GetByCode/{code}")]
        [AllowAnonymous]
        public async Task<ActionResult<MemberTierDetailsGetDto>> Get(string code)
        { 
            var entity = await _appService.GetByCode(code);
            return Ok(entity);
        }
    }
}
