using Hotel.Application.HotelAppService;
using Hotel.Application.HotelAppService.Dtos;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace Hotel.Host.Controllers
{
    [Authorize]
    public class HotelController : BaseController<IHotelAppService, Domain.Models.Hotel, HotelGetDto, HotelGetDto, HotelCreateDto, HotelUpdateDto, SieveModel>
    {
        IHotelAppService _appService;
        public HotelController(IHotelAppService appService) : base(appService)
        {
            _appService = appService;
        }
        [HttpGet("Details/{id}")]
        public async Task<ActionResult<HotelGetDetailsDto>> GetHotelDetailsWithReviews(int id)
        {
            try
            {
                var hotelDetails = await _appService.GetWithDetal(id);
                if (hotelDetails == null)
                {
                    return NotFound();
                }
                return Ok(hotelDetails);
            }
            catch (Exception ex)
            {
                // Handle any exceptions, you can log the error or return a more specific message if needed
                return StatusCode(StatusCodes.Status500InternalServerError, "Error fetching hotel details");
            }
        }
        /*
        [HttpGet("WithContactInfo")]
        public async Task<ActionResult<IEnumerable<HotelGetDto>>> GetAll(SieveModel input)
        {
            try
            {
                var hotels = await _appService.GetAllWithContactInfo(input);
                if (hotels == null)
                {
                    return NotFound();
                }
                return Ok(hotels);
            }
            catch (Exception ex)
            {
                // Handle any exceptions, you can log the error or return a more specific message if needed
                return StatusCode(StatusCodes.Status500InternalServerError, "Error fetching hotel info");
            }
        }
        */
    }
}
