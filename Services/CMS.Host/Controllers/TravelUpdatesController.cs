using CMS.Application.StaticComponentAppService.Dto;
using CMS.Application.StaticComponentAppService;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using CMS.Application.TravelUpdatesAppService;
using CMS.Application.TravelUpdatesAppService.Dto;

namespace CMS.Host.Controllers
{
    public class TravelUpdatesController : BaseController<ITravelUpdatesAppService, Domain.Models.TravelUpdates, TravelUpdatesGetDto, TravelUpdatesGetDto, TravelUpdatesCreateDto, TravelUpdatesUpdateDto, SieveModel>
    {
        ITravelUpdatesAppService _appService;
        public TravelUpdatesController(ITravelUpdatesAppService appService) : base(appService, Servics.CMS)
        {
            _appService = appService;
        }


    }
}