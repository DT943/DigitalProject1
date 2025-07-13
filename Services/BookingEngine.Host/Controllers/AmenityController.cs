using BookingEngine.Application.OTAUserAppService.Dtos;
using BookingEngine.Application.OTAUserAppService;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using BookingEngine.Application.AmenitiesAppService;
using BookingEngine.Application.AmenitiesAppService.Dtos;
using BookingEngine.Application.AirPortAppService.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace BookingEngine.Host.Controllers
{
    public class AmenityController : BaseController<IAmenitiesAppService, Domain.Models.Amenity, AmenityGetDto, AmenityGetDto, AmenityCreateDto, AmenityUpdateDto, SieveModel>
    {
        public AmenityController(IAmenitiesAppService appService) : base(appService, Servics.BookingEngine)
        {

        }

        [HttpGet]
        [AllowAnonymous] // Allow access without authentication
        public override async Task<ActionResult<AmenityGetDto>> GetAll([FromQuery] SieveModel sieve)
        {
            var entity = await _appService.GetAll(sieve);
            return Ok(entity);
        }

    }
}
