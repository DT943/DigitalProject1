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
        ITravelAgentApplicationAppService _travelAgentApplicationAppServiceAppService;

        IAuthenticationAppService _authenticationAppService;
        public TravelAgentOfficeController(ITravelAgentOfficeAppService appService, ITravelAgentApplicationAppService travelAgentApplicationAppServiceAppService, IAuthenticationAppService authenticationAppService) : base(appService, Servics.B2B)
        {
            _appService = appService;
            _authenticationAppService = authenticationAppService;
            _travelAgentApplicationAppServiceAppService = travelAgentApplicationAppServiceAppService;
        }


        [HttpGet("approve/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<TravelAgentEmployeeGetDto>> Approve(int id)
        {
            var user = HttpContext.User;

            if (!UserHasPermission("Admin"))
            {
                return Forbid();
            }

            var travelAgentApplicationDto = _travelAgentApplicationAppServiceAppService.Get(id);

            TravelAgentOfficeGetDto dto = await _appService.Get(id);
            if (dto == null)
                return BadRequest(new ErrorModel
                {
                    IsAuthenticated = false,
                    Message = "Not Found"
                });


            var result = await _authenticationAppService.AddB2BUserAsync(new Authentication.Application.Dtos.AddUserDto
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.FirstEmail
            });

            if (!result.IsAuthenticated)
                return BadRequest(new ErrorModel
                {
                    IsAuthenticated = result.IsAuthenticated,
                    Message = result.Message
                });



            return Ok(dto);
        }

    }
}