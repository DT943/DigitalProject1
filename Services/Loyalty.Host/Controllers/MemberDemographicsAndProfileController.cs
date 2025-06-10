using Infrastructure.Service.Controllers;
using Loyalty.Application.MemberAddressDetailsAppService.Dtos;
using Loyalty.Application.MemberAddressDetailsAppService;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using Loyalty.Application.MemberDemographicsAndProfileAppService;
using Loyalty.Application.MemberDemographicsAndProfileAppService.Dto;
using Microsoft.AspNetCore.Authorization;
using Authentication.Application;
using Authentication.Domain.Models;
using Loyalty.Application.MemberDemographicsAndProfileAppService.Validations;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;


namespace Loyalty.Host.Controllers
{
    [Authorize]

    public class MemberDemographicsAndProfileController : BaseController<IMemberDemographicsAndProfileAppService, Domain.Models.MemberDemographicsAndProfile, MemberDemographicsAndProfileGetAllDto, MemberDemographicsAndProfileGetDto, MemberDemographicsAndProfileCreateDto, MemberDemographicsAndProfileUpdateDto, SieveModel>
    {


        public MemberDemographicsAndProfileController(IMemberDemographicsAndProfileAppService appService, MemberDemographicsAndProfileValidator memberDemographicsAndProfileValidator) : base(appService, Servics.Loyalty)
        {


        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [AllowAnonymous]

        public override async Task<ActionResult<MemberDemographicsAndProfileGetDto>> Create(MemberDemographicsAndProfileCreateDto createDto)
        {


            var user = HttpContext.User;
            int bonus = 100;
            if (user.IsInRole($"{ServiceName}-Officer"))
            {
                bonus = 0;
            }
 

            var entity = await _appService.CreateWithBonus(createDto, bonus);
            return Ok(entity);
        }


        [HttpGet("Details")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> GetMemberDemographicsAndProfileGetDtoByUserCode()
        {
            var user = HttpContext.User;
            return Ok(await _appService.GetMemberDemographicsAndProfileGetDtoByUserCode());
        }
    }
}
