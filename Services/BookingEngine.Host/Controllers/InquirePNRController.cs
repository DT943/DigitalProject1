using BookingEngine.Application.WrappingAppService.WrappingBookingAppService;
using BookingEngine.Application.WrappingAppService.WrappingBookingAppService.Dtos;
using BookingEngine.Application.WrappingAppService.WrappingInquirePNRAppService;
using BookingEngine.Application.WrappingAppService.WrappingInquirePNRAppService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BookingEngine.Host.Controllers
{
    [ApiController]

    public class InquirePNRController : Controller
    {

        private readonly IWrappingInquirePNRAppService _inquirePNRAppService;

        public InquirePNRController(IWrappingInquirePNRAppService inquirePNRAppService)
        {
            _inquirePNRAppService = inquirePNRAppService;
        }

        [HttpPost("InquirePNR")]
        public async Task<IActionResult> CreateOnHoldBooking(InquirePNRCreateDto inquirePNRCreateDto)
        {
            var inquirePNR = await _inquirePNRAppService.InquirePNRAsync(inquirePNRCreateDto);


            // Check for error in the response
            if (inquirePNR?.Status?.ToLower() == "error")
            {
                var errorMessage = string.Join("; ", inquirePNR.Errors ?? new List<string> { "Unknown error occurred." });
                return BadRequest(new
                {
                    status = "error",
                    errors = inquirePNR.Errors,
                });
            }

            return Ok(inquirePNR);

        }

    }
}

