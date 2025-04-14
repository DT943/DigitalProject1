using B2B.Application.TravelAgentEmployeeAppService.Dto;
using B2B.Application.TravelAgentEmployeeAppService;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using B2B.Application.TravelAgentApplicationAppService;
using B2B.Application.TravelAgentApplicationAppService.Dto;
using Microsoft.AspNetCore.Authorization;

namespace B2B.Host.Controllers
{
    public class TravelAgentApplicationController : BaseController<ITravelAgentApplicationAppService, Domain.Models.TravelAgentApplication, TravelAgentApplicationGetAllDto, TravelAgentApplicationGetDto, TravelAgentApplicationCreateDto, TravelAgentApplicationUpdateDto, SieveModel>
    {
        private readonly ITravelAgentApplicationAppService _appService;
        public TravelAgentApplicationController(ITravelAgentApplicationAppService appService) : base(appService, Servics.B2B)
        {
            _appService = appService;
        }

        [AllowAnonymous]
        public override async Task<ActionResult<TravelAgentApplicationGetDto>> Create(TravelAgentApplicationCreateDto createDto)
        {
            var entity = await _appService.Create(createDto);
            return Ok(entity);
        }
    }
}