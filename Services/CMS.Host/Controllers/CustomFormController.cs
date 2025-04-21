using CMS.Application.ComponentMetadataAppService.Dto;
using CMS.Application.ComponentMetadataAppService;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using CMS.Application.CustomFormAppService;
using CMS.Application.CustomFormAppService.Dto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace CMS.Host.Controllers
{
    public class CustomFormController : BaseController<ICustomFormAppService, Domain.Models.CustomForm, CustomFormGetDto, CustomFormGetDto, CustomFormCreateDto, CustomFormUpdateDto, SieveModel>
    {
        ICustomFormAppService _appService;
        public CustomFormController(ICustomFormAppService appService) : base(appService, Servics.CMS)
        {
            _appService = appService;
        }

        [HttpPost]
        [AllowAnonymous]
        public override async Task<ActionResult<CustomFormGetDto>> Create(CustomFormCreateDto dto)
        { 
            var entity = await _appService.Create(dto);
            return Ok(entity);
        }


    }
}

