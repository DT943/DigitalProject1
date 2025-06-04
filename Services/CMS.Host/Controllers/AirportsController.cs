using CMS.Application.ComponentAppService.Dto;
using CMS.Application.ComponentAppService;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using CMS.Application.AirportsAppService;
using CMS.Application.AirportsAppService.Dto;

namespace CMS.Host.Controllers
{
    public class AirportsController : BaseController<IAirportsAppService, Domain.Models.Airports, AirportsGetDto, AirportsGetDto, AirportsCreateDto, AirportsUpdateDto, SieveModel>
    {
         public AirportsController(IAirportsAppService appService) : base(appService, Servics.CMS)
         { 

         }
    }
}