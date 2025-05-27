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
            int bonus = 500;
            if (user.IsInRole($"{ServiceName}-Officer"))
            {
                bonus = 400;
            }
 

            var entity = await _appService.CreateWithBonus(createDto, bonus);
            return Ok(entity);
        }
    }
}
