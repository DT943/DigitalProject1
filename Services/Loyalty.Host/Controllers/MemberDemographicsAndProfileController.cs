using Infrastructure.Service.Controllers;
using Loyalty.Application.MemberAddressDetailsAppService.Dtos;
using Loyalty.Application.MemberAddressDetailsAppService;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using Loyalty.Application.MemberDemographicsAndProfileAppService;
using Loyalty.Application.MemberDemographicsAndProfileAppService.Dto;
using Microsoft.AspNetCore.Authorization;

namespace Loyalty.Host.Controllers
{
    public class MemberDemographicsAndProfileController : BaseController<IMemberDemographicsAndProfileAppService, Domain.Models.MemberDemographicsAndProfile, MemberDemographicsAndProfileGetAllDto, MemberDemographicsAndProfileGetDto, MemberDemographicsAndProfileCreateDto, MemberDemographicsAndProfileUpdateDto, SieveModel>
    {
        public MemberDemographicsAndProfileController(IMemberDemographicsAndProfileAppService appService) : base(appService, Servics.Loyalty)
        {
        }

        [HttpPost]
        [AllowAnonymous]
        public override async Task<ActionResult<MemberDemographicsAndProfileGetDto>> Create(MemberDemographicsAndProfileCreateDto dto)
        {
            var entity = await _appService.Create(dto);
            return Ok(entity);
        }
    }
}
