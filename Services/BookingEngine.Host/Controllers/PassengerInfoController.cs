using BookingEngine.Application.OTAUserAppService.Dtos;
using BookingEngine.Application.OTAUserAppService;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using BookingEngine.Application.PassengerInfo;
using BookingEngine.Application.PassengerInfo.Dtos;

namespace BookingEngine.Host.Controllers
{
    public class PassengerInfoController : BaseController<IPassengerInfoAppService, Domain.Models.PassengerInfo, PassengerInfoGetDto, PassengerInfoGetDto, PassengerInfoCreateDto, PassengerInfoUpdateDto, SieveModel>
    {
        public PassengerInfoController(IPassengerInfoAppService appService) : base(appService, Servics.BookingEngine)
        {
        }
    }
}
