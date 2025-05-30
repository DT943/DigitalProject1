﻿using B2B.Application.TravelAgentEmployeeAppService.Dto;
using B2B.Application.TravelAgentEmployeeAppService;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using B2B.Application.TravelAgentApplicationAppService;
using B2B.Application.TravelAgentApplicationAppService.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Authentication.Domain.Models;
using Authentication.Application;

namespace B2B.Host.Controllers
{
    public class TravelAgentApplicationController : BaseController<ITravelAgentApplicationAppService, Domain.Models.TravelAgentApplication, TravelAgentApplicationGetAllDto, TravelAgentApplicationGetDto, TravelAgentApplicationCreateDto, TravelAgentApplicationUpdateDto, SieveModel>
    {
        private readonly ITravelAgentApplicationAppService _appService;
        private IAuthenticationAppService _authenticationAppService;

        public TravelAgentApplicationController(ITravelAgentApplicationAppService appService, IAuthenticationAppService authenticationAppService) : base(appService, Servics.B2B)
        {
            _appService = appService;
            _authenticationAppService = authenticationAppService;
        }
        [HttpGet("/get-by-code/{code}")]
        public async Task<ActionResult<TravelAgentApplicationGetDto>> GetByCode(string code)
        {

            if (!UserHasPermission("Admin", "Manager", "Supervisor", "Officer"))
            {
                return Forbid();
            }

            return Ok(await _appService.GetByCode(code));
        }

        [AllowAnonymous]
        public override async Task<ActionResult<TravelAgentApplicationGetDto>> Create(TravelAgentApplicationCreateDto createDto)
        {
            var entity = await _appService.Create(createDto);
            return Ok(entity);
        }
 
    }
}