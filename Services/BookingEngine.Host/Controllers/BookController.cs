using BookingEngine.Application.PaymantAppService.Dtos;
using BookingEngine.Application.PaymantAppService;
using BookingEngine.Application.WrappingAppService.WrappingBookingAppService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using BookingEngine.Application.Reservation;
using BookingEngine.Application.WrappingAppService.WrappingBookingAppService.Dtos;

namespace BookingEngine.Host.Controllers
{
    [ApiController]
    public class BookController : Controller
    {
        private readonly IWrappingOnHoldBookingAppService _onHoldBookingAppService;
       // private readonly IReservationAppService _reservationAppService;

        public BookController(IWrappingOnHoldBookingAppService onHoldBookingAppService)//, IReservationAppService reservationAppService)
        {
            _onHoldBookingAppService = onHoldBookingAppService;
            //_reservationAppService = reservationAppService;
        }
        
        [HttpPost("OnHoldBooking")]
        public async Task<IActionResult> CreateOnHoldBooking(BookCreateDto bookCreateDto)
        {
            var onholdbooking = await _onHoldBookingAppService.OnHoldBookingFlightAsync(bookCreateDto);
            
            
            // Check for error in the response
            if (onholdbooking?.Status?.ToLower() == "error")
            {
                var errorMessage = string.Join("; ", onholdbooking.Errors ?? new List<string> { "Unknown error occurred." });
                return BadRequest(new
                {
                    status = "error",
                    errors = onholdbooking.Errors,
                });
            }

            return Ok(onholdbooking);

        }

    }
}
