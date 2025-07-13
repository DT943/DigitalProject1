using BookingEngine.Application.PassengerInfo.Dtos;
using BookingEngine.Application.PassengerInfo;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using BookingEngine.Application.POSAppService.Dtos;
using BookingEngine.Application.POSAppService;
using BookingEngine.Application.AirPortAppService.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace BookingEngine.Host.Controllers
{
    public class POSController : BaseController<IPOSAppService, Domain.Models.POS, POSGetDto, POSGetDto, POSCreateDto, POSUpdateDto, SieveModel>
    {
        public POSController(IPOSAppService appService) : base(appService, Servics.BookingEngine)
        {

        }

        [HttpGet("{id}")]
        [AllowAnonymous] // Allow access without authentication
        public override async Task<ActionResult<POSGetDto>> Get(int id)
        {
            var entity = await _appService.Get(id);
            return Ok(entity);

        }

        [HttpGet]
        [AllowAnonymous] // Allow access without authentication
        public override async Task<ActionResult<POSGetDto>> GetAll([FromQuery] SieveModel sieve)
        {
            var entity = await _appService.GetAll(sieve);
            return Ok(entity);

        }


    }
}



