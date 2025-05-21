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


namespace Loyalty.Host.Controllers
{
    public class MemberDemographicsAndProfileController : BaseController<IMemberDemographicsAndProfileAppService, Domain.Models.MemberDemographicsAndProfile, MemberDemographicsAndProfileGetAllDto, MemberDemographicsAndProfileGetDto, MemberDemographicsAndProfileCreateDto, MemberDemographicsAndProfileUpdateDto, SieveModel>
    {


        public MemberDemographicsAndProfileController(IMemberDemographicsAndProfileAppService appService, MemberDemographicsAndProfileValidator memberDemographicsAndProfileValidator) : base(appService, Servics.Loyalty)
        {


        }

        [HttpPost]
        [AllowAnonymous]
        public override async Task<ActionResult<MemberDemographicsAndProfileGetDto>> Create(MemberDemographicsAndProfileCreateDto createDto)
        {

            var entity = await _appService.Create(createDto);
            return Ok(entity);
        }
    }
}
