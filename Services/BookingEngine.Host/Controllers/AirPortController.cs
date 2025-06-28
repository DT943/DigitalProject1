using BookingEngine.Application.AirPortAppService;
using BookingEngine.Application.AirPortAppService.Dtos;
using Infrastructure.Service.Controllers;
using Sieve.Models;
using static Infrastructure.Domain.Consts;

namespace BookingEngine.Host.Controllers
{
    public class AirPortController : BaseController<IAirPortAppService, Domain.Models.AirPort, AirPortGetDto, AirPortGetDto, AirPortCreateDto, AirPortUpdateDto, SieveModel>
    {
        public AirPortController(IAirPortAppService appService) : base(appService, Servics.BookingEngine)
        {
        }

    }

}
