using CMS.Application.ComponentAppService.Dto;
using CMS.Application.ComponentAppService;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using CMS.Application.StaticComponentAppService;
using CMS.Application.StaticComponentAppService.Dto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace CMS.Host.Controllers
{
    public class StaticComponentController : BaseController<IStaticComponentAppService, Domain.Models.StaticComponent, StaticComponentGetDto, StaticComponentGetDto, StaticComponentCreateDto, StaticComponentUpdateDto, SieveModel>
    {
        IStaticComponentAppService _appService;
        public StaticComponentController(IStaticComponentAppService appService) : base(appService, Servics.CMS)
        {
            _appService = appService;
        }

        [HttpGet]
        [AllowAnonymous]
        public override async Task<ActionResult<StaticComponentGetDto>> GetAll([FromQuery] SieveModel sieve)
        {
          
            var entity = await _appService.GetAll(sieve);
            return Ok(entity);
        }
    }
}