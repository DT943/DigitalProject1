using B2B.Application.TravelAgentOffice.Dto;
using B2B.Application.TravelAgentOffice;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using B2B.Application.TravelAgentEmployeeAppService;
using B2B.Application.TravelAgentEmployeeAppService.Dto;

namespace B2B.Host.Controllers
{
    public class TravelAgentEmployeeController : BaseController<ITravelAgentEmployeeAppService, Domain.Models.TravelAgentEmployee, TravelAgentEmployeeGetAllDto, TravelAgentEmployeeGetDto, TravelAgentEmployeeCreateDto, TravelAgentEmployeeUpdateDto, SieveModel>
    {
        public TravelAgentEmployeeController(ITravelAgentEmployeeAppService appService) : base(appService, Servics.B2B)
        {
        }
    }
}
