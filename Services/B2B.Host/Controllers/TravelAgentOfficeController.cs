using Authentication.Application;
using Authentication.Domain.Models;
using B2B.Application.TravelAgentApplicationAppService;
using B2B.Application.TravelAgentApplicationAppService.Dto;
using B2B.Application.TravelAgentEmployeeAppService.Dto;
using B2B.Application.TravelAgentOffice;
using B2B.Application.TravelAgentOffice.Dto;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;

namespace B2B.Host.Controllers
{
    public class TravelAgentOfficeController : BaseController<ITravelAgentOfficeAppService, Domain.Models.TravelAgentOffice, TravelAgentOfficeGetAllDto, TravelAgentOfficeGetDto, TravelAgentOfficeCreateDto, TravelAgentOfficeUpdateDto, SieveModel>
    {
        ITravelAgentOfficeAppService _appService;
 
        public TravelAgentOfficeController(ITravelAgentOfficeAppService appService) : base(appService, Servics.B2B)
        {
            _appService = appService;
        }


        [HttpPost("approve")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<TravelAgentEmployeeGetDto>> Approve(TravelAgentProcessApproveDto travelAgentProcessApproveDto)
        {
            var user = HttpContext.User;

            if (!UserHasPermission("Admin"))
            {
                return Forbid();
            }

            return Ok(await _appService.Approve(travelAgentProcessApproveDto));
        }

    }
}