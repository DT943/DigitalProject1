using BookingEngine.Application.PassengerInfo.Dtos;
using BookingEngine.Application.PassengerInfo;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using BookingEngine.Application.POSAppService.Dtos;
using BookingEngine.Application.POSAppService;

namespace BookingEngine.Host.Controllers
{
    public class POSController : BaseController<IPOSAppService, Domain.Models.POS, POSGetDto, POSGetDto, POSCreateDto, POSUpdateDto, SieveModel>
    {
        public POSController(IPOSAppService appService) : base(appService, Servics.BookingEngine)
        {

        }
    }


}



