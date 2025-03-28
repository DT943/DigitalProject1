using Hotel.Application.RoomAppService.Dtos;
using Hotel.Application.RoomAppService;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using Hotel.Application.RoomAppService;
using Hotel.Application.HotelAppService.Dtos;
using Hotel.Domain.Models;
using Gallery.Application.FileAppservice.Dtos;

namespace Hotel.Host.Controllers
{
    [Authorize]
    public class RoomController : BaseController<IRoomAppService, Domain.Models.Room, RoomOutputDto, RoomOutputDto, RoomCreateDto, RoomUpdateDto, SieveModel>
    {
        IRoomAppService _appService;
        public RoomController(IRoomAppService appService) : base(appService, "Hotel")
        {
            _appService = appService;
        }

        public override async Task<ActionResult<RoomOutputDto>> Create([FromForm] RoomCreateDto createDto)
        {
            return await base.Create(createDto);
        }

        [HttpGet("ByHotelId/{hotelId}")]
        public async Task<ActionResult<IEnumerable<RoomOutputDto>>> GetRoomsByHotelIdAsync(int hotelId)
        {
            if (!UserHasPermission("Admin", "Manager", "Supervisor", "Officer"))
            {
                return Forbid();
            }
            try
            {
                var rooms = await _appService.GetRoomsByHotelIdAsync(hotelId);
                if (rooms == null)
                {
                    return NotFound();
                }
                return Ok(rooms);
            }
            catch (Exception ex)
            {
                // Handle any exceptions, you can log the error or return a more specific message if needed
                return StatusCode(StatusCodes.Status500InternalServerError, "Error fetching room info");
            }
        }
        
    }
}