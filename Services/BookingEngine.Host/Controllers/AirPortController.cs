using BookingEngine.Application.AirPortAppService;
using BookingEngine.Application.AirPortAppService.Dtos;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;

namespace BookingEngine.Host.Controllers
{
    public class AirPortController : BaseController<IAirPortAppService, Domain.Models.AirPort, AirPortGetDto, AirPortGetDto, AirPortCreateDto, AirPortUpdateDto, SieveModel>
    {
        public AirPortController(IAirPortAppService appService) : base(appService, Servics.BookingEngine)
        {

        }

        [HttpGet("{id}")]
        [AllowAnonymous] // Allow access without authentication
        public override async Task<ActionResult<AirPortGetDto>> Get(int id)
        {
            var entity = await _appService.Get(id);
            return Ok(entity);
        }

        [HttpGet]
        [AllowAnonymous] // Allow access without authentication
        public override async Task<ActionResult<AirPortGetDto>> GetAll([FromQuery] SieveModel sieve)
        {
            var entity = await _appService.GetAll(sieve);
            return Ok(entity);
        }

        [HttpPost("GetSpecific")]
        [AllowAnonymous] 
        
        public async Task<ActionResult<AirPortGetDto>> GetSpecific([FromQuery] SieveModel sieve, [FromHeader] string from)
        {
            var entity = await _appService.GetSpecific(sieve,from);
            return Ok(entity);
        }
    }

}
