using BookingEngine.Application.AirPortAppService.Dtos;
using BookingEngine.Application.AirPortAppService;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using BookingEngine.Application.OTAUserAppService.Dtos;
using BookingEngine.Application.OTAUserAppService;

namespace BookingEngine.Host.Controllers
{

    public class OTAUserController : BaseController<IOTAUserAppService, Domain.Models.OTAUser, OTAUserGetDto, OTAUserGetDto, OTAUserCreateDto, OTAUserUpdateDto, SieveModel>
    {
        public OTAUserController(IOTAUserAppService appService) : base(appService, Servics.BookingEngine)
        {
            
        }
    }
}
