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
        private readonly IAuthenticationAppService _authenticationAppService;
        private MemberDemographicsAndProfileValidator _memberDemographicsAndProfileValidator;
        public MemberDemographicsAndProfileController(IMemberDemographicsAndProfileAppService appService, IAuthenticationAppService authenticationAppService, MemberDemographicsAndProfileValidator memberDemographicsAndProfileValidator) : base(appService, Servics.Loyalty)
        {
            authenticationAppService = _authenticationAppService;
            _memberDemographicsAndProfileValidator = memberDemographicsAndProfileValidator;
        }

        [HttpPost]
        [AllowAnonymous]
        public override async Task<ActionResult<MemberDemographicsAndProfileGetDto>> Create(MemberDemographicsAndProfileCreateDto createDto)
        {

            var validationResult = await _memberDemographicsAndProfileValidator.ValidateAsync(createDto, options => options.IncludeRuleSets("create", "default"));
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var result =  await _authenticationAppService.AddUserAsync(new Authentication.Application.Dtos.AddUserDto
            {
                FirstName = createDto.FirstName,
                LastName = createDto.LastName,
                Email = createDto.Email
            });

        if (!result.IsAuthenticated)
            return BadRequest(new ErrorModel
            {
                IsAuthenticated = result.IsAuthenticated,
                Message = result.Message
            });

            var entity = await _appService.Create(createDto);
            return Ok(entity);
        }
    }
}
