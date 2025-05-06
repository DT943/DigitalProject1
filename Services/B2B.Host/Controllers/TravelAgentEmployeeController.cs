using Authentication.Application;
using Authentication.Domain.Models;
using B2B.Application.TravelAgentApplicationAppService;
using B2B.Application.TravelAgentApplicationAppService.Dto;
using B2B.Application.TravelAgentEmployeeAppService;
using B2B.Application.TravelAgentEmployeeAppService.Dto;
using B2B.Application.TravelAgentEmployeeAppService.Validations;
using B2B.Application.TravelAgentOffice;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;

namespace B2B.Host.Controllers
{
    [Authorize]

    public class TravelAgentEmployeeController : BaseController<ITravelAgentEmployeeAppService, Domain.Models.TravelAgentEmployee, TravelAgentEmployeeGetAllDto, TravelAgentEmployeeGetDto, TravelAgentEmployeeCreateDto, TravelAgentEmployeeUpdateDto, SieveModel>
    {

        private IAuthenticationAppService _authenticationAppService;
        private TravelAgentEmployeeValidator _travelAgentEmployeeValidator;
        ITravelAgentEmployeeAppService _appService;
        ITravelAgentApplicationAppService _travelAgentAppService;
        ITravelAgentOfficeAppService _officeAppService;
        public TravelAgentEmployeeController(ITravelAgentEmployeeAppService appService, ITravelAgentOfficeAppService officeAppService, ITravelAgentApplicationAppService travelAgentAppService, IAuthenticationAppService authenticationAppService, TravelAgentEmployeeValidator travelAgentEmployeeValidator) : base(appService, Servics.B2B)
        {
            _appService = appService;
            _travelAgentEmployeeValidator = travelAgentEmployeeValidator;
            _travelAgentAppService = travelAgentAppService;

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

            EmployeeApplicationGetDto dto = await _travelAgentAppService.GetEmployeeById(id);
            if (dto == null)
                return BadRequest(new ErrorModel
                {
                    IsAuthenticated = false,
                    Message = "Not Found"
                });


            var result = await _authenticationAppService.AddB2BUserAsync(new Authentication.Application.Dtos.AddUserDto
            {
                FirstName = dto.EmployeeFirstName,
                LastName = dto.EmployeeLastName,
                Email = dto.EmployeeEmail
            });

            if (!result.IsAuthenticated)
                return BadRequest(new ErrorModel
                {
                    IsAuthenticated = result.IsAuthenticated,
                    Message = result.Message
                });

            var agent = await this.Create(new TravelAgentEmployeeCreateDto
            {
                EmployeeEmail = dto.EmployeeEmail,
                EmployeeFirstName = dto.EmployeeFirstName,
                EmployeeLastName = dto.EmployeeLastName,
                PhoneNumber = dto.PhoneNumber,
                UserCode = result.Code,
                TravelAgentOfficeId = 1
            });


            return Ok(dto);
        }

    }
}
