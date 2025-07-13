using BookingEngine.Application.PaymantAppService.Dtos;
using BookingEngine.Application.PaymantAppService;
using BookingEngine.Application.WrappingAppService.WrappingBookingAppService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using BookingEngine.Application.Reservation;
using BookingEngine.Application.WrappingAppService.WrappingBookingAppService.Dtos;
using BookingEngine.Application.Filters;
using BookingEngine.Application.OTAUserAppService.Dtos;
using BookingEngine.Application.OTAUserAppService;
using BookingEngine.Application.OTAUserService;
using BookingEngine.Application.POSAppService;
using BookingEngine.Application.ReservationInfo.Dtos;
using BookingEngine.Application.LocationAppService;

namespace BookingEngine.Host.Controllers
{
    [ApiController]
    public class BookController : Controller
    {
        private readonly IWrappingOnHoldBookingAppService _onHoldBookingAppService;
        private readonly IReservationAppService _reservationAppService;
        private readonly IOTAUserAppService _oTAUserAppService;
        private readonly IEncryptionAppService _encryptionAppService;
        private readonly IPOSAppService _posAppService;
        private readonly ILocationAppService _locationAppService;


        public BookController(IWrappingOnHoldBookingAppService onHoldBookingAppService,
            IEncryptionAppService encryptionAppService,
            IPOSAppService posAppService,
            IReservationAppService reservationAppService,
            ILocationAppService locationAppService,
            IOTAUserAppService oTAUserAppService)
        {
            _onHoldBookingAppService = onHoldBookingAppService;
            _reservationAppService = reservationAppService;
            _encryptionAppService = encryptionAppService;
            _oTAUserAppService = oTAUserAppService;
            _locationAppService = locationAppService;
            _posAppService = posAppService;
        }
        
        [HttpPost("OnHoldBooking")]
        public async Task<IActionResult> CreateOnHoldBooking(BookCreateDto bookCreateDto)
        {



            var location = await _locationAppService.GetByCountryCode(bookCreateDto.ContactInfo.CountryCode);


            var code = location.LocationCode;
            bookCreateDto.ContactInfo.CountryName = location.CountryName;
            bookCreateDto.ContactInfo.CountryCode = location.CountryCode;


            var oTAUser = await _oTAUserAppService.GetByPOSId(bookCreateDto.PosId);

            var pos = await _posAppService.GetPosCode(bookCreateDto.PosId);


            oTAUser.EncryptedPassword = _encryptionAppService.Decrypt(oTAUser.EncryptedPassword);


            var onholdbooking = await _onHoldBookingAppService.OnHoldBookingFlightAsync(bookCreateDto, oTAUser, code);
            
            
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
            var reservationCreateDto = new ReservationCreateDto
            {
                Pos = pos,
                TransactionId = bookCreateDto.TransactionId,
                PNR = onholdbooking.PNR,
                PaymentAmount = bookCreateDto.PaymentAmount,
                FlightType = bookCreateDto.FlightType,
                FlightClass = bookCreateDto.FlightClass,
                CheckOutUrl = "",
                PaymentStatus = "unpaid",
                ContactInfo = bookCreateDto.ContactInfo
            };

            //Store Booking 
            var reservation = await _reservationAppService.Create(reservationCreateDto);


            return Ok(onholdbooking);

        }

    }
}
