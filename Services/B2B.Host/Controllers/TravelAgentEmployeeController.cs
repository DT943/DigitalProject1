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

    }
}
