using B2B.Application.TravelAgentOffice;
using B2B.Application.TravelAgentOffice.Dto;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;

namespace B2B.Host.Controllers
{
    public class TravelAgentOfficeController : BaseController<ITravelAgentOfficeAppService, Domain.Models.TravelAgentOffice, TravelAgentOfficeGetAllDto, TravelAgentOfficeGetDto, TravelAgentOfficeCreateDto, TravelAgentOfficeUpdateDto, SieveModel>
    {
        public TravelAgentOfficeController(ITravelAgentOfficeAppService appService) : base(appService, Servics.B2B)
        {
        }
    }
}