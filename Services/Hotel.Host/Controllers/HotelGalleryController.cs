using Hotel.Application.HotelAppService.Dtos;
using Hotel.Application.HotelAppService;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using Hotel.Application.HotelGalleryAppService;
using Hotel.Application.HotelGalleryAppService.Dtos;
using Hotel.Application.RoomAppService.Dtos;

namespace Hotel.Host.Controllers
{
    [Authorize]
    public class HotelGalleryController : BaseController<IHotelGalleryAppService, Domain.Models.HotelGallery, HotelGalleryOutputDto, HotelGalleryOutputDto, HotelGalleryCreateDto, HotelGalleryUpdateDto, SieveModel>
    {
        IHotelGalleryAppService _appService;
        public HotelGalleryController(IHotelGalleryAppService appService) : base(appService, "Hotel")
        {
            _appService = appService;
        }
        [HttpGet("ByHotelId/{hotelId}")]
        public async Task<ActionResult<IEnumerable<HotelGalleryOutputDto>>> GetHotelGalleryByHotelIdAsync(int hotelId)
        {
            try
            {
                var gallerys = await _appService.GetHotelGalleryByHotelIdAsync(hotelId);
                if (gallerys == null)
                {
                    return NotFound();
                }
                return Ok(gallerys);
            }
            catch (Exception ex)
            {
                // Handle any exceptions, you can log the error or return a more specific message if needed
                return StatusCode(StatusCodes.Status500InternalServerError, "Error fetching gallery info");
            }
        }

    }

}
