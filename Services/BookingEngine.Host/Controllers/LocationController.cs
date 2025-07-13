using BookingEngine.Application.AmenitiesAppService.Dtos;
using BookingEngine.Application.AmenitiesAppService;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using BookingEngine.Application.LocationAppService.Dtos;
using BookingEngine.Application.LocationAppService;

namespace BookingEngine.Host.Controllers
{

    public class LocationController : BaseController<ILocationAppService, Domain.Models.Location, LocationGetDto, LocationGetDto, LocationCreateDto, LocationUpdateDto, SieveModel>
    {
        public LocationController(ILocationAppService appService) : base(appService, Servics.BookingEngine)
        {

        }

        [HttpGet]
        [AllowAnonymous] // Allow access without authentication
        public override async Task<ActionResult<LocationGetDto>> GetAll([FromQuery] SieveModel sieve)
        {
            var entity = await _appService.GetAll(sieve);
            return Ok(entity);
        }

    }

}
