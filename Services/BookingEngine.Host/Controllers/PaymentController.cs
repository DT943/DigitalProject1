using BookingEngine.Application.Filters;
using BookingEngine.Application.LocationAppService;
using BookingEngine.Application.LocationAppService.Dtos;
using BookingEngine.Application.OTAUserAppService;
using BookingEngine.Application.OTAUserAppService.Dtos;
using BookingEngine.Application.PaymantAppService;
using BookingEngine.Application.PaymantAppService.Dtos;
using BookingEngine.Application.POSAppService;
using BookingEngine.Application.Reservation;
using BookingEngine.Application.ReservationInfo.Dtos;
using BookingEngine.Application.WrappingAppService.WrappingBookingAppService;
using BookingEngine.Application.WrappingAppService.WrappingBookingAppService.Dtos;
using BookingEngine.Application.WrappingAppService.WrappingInquirePNRAppService;
using BookingEngine.Data.Migrations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Options;
using Sieve.Models;
using Stripe;

namespace BookingEngine.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : Controller
    {
        private readonly IPaymentAppService _paymentAppService;
        private readonly StripeSettingsDto _stripeSettings;
        private readonly IWrappingOnHoldBookingAppService _onHoldBookingAppService;
        private readonly IReservationAppService _reservationAppService;
        private readonly IOTAUserAppService _oTAUserAppService;
        private readonly ILocationAppService _locationAppService;

        private readonly ILogger<PaymentController> _logger;
        private readonly IEncryptionAppService _encryptionAppService;
        private readonly IWrappingInquirePNRAppService _inquirePNRAppService;

        private readonly IPOSAppService _posAppService;

        public PaymentController(IPaymentAppService paymentAppService, 
            IWrappingOnHoldBookingAppService onHoldBookingAppService, 
            IReservationAppService reservationAppService,
            ILocationAppService locationAppService,
            IOTAUserAppService oTAUserAppService,
            IPOSAppService posAppService,
            IEncryptionAppService encryptionAppService,
            IWrappingInquirePNRAppService wrappingInquirePNRAppService,
            IOptions<StripeSettingsDto> stripeOptions, ILogger<PaymentController> logger)
        {
            _paymentAppService = paymentAppService;
            _stripeSettings =  stripeOptions.Value;
            _onHoldBookingAppService = onHoldBookingAppService;
            _reservationAppService = reservationAppService;
            _oTAUserAppService = oTAUserAppService;
            _locationAppService = locationAppService;
            _logger = logger;
            _encryptionAppService = encryptionAppService;
            _posAppService = posAppService;
            _inquirePNRAppService = wrappingInquirePNRAppService;

        }


        [HttpPost("Checkout")]
        public async Task<IActionResult> CreateCheckout(PaymentCreateDto paymentCreateDto)
        {
            try
            {
                _logger.LogWarning("Start Stripe {paymentCreateDto}:",paymentCreateDto);


                var location = await _locationAppService.GetByCountryCode(paymentCreateDto.BookingInfo.ContactInfo.CountryCode);

                _logger.LogWarning("location {location}:", location);

                var posCode = "";
                BookingEngine.Application.POSAppService.Dtos.POSGetDto pos = null;

                if (paymentCreateDto.BookingInfo.PosId != 0)
                {
                    pos = await _posAppService.Get(paymentCreateDto.BookingInfo.PosId);
                    paymentCreateDto.BookingInfo.PosId = pos.Id;
                }
                else
                {
                    var originCode = paymentCreateDto.BookingInfo.Segments[0].OriginCode;
                    if (originCode == "EBL" || originCode == "BGW" || originCode == "BSR")
                    {
                        posCode = "BGW";
                    }
                    else if (originCode == "DAM" || originCode == "ALP")
                    {
                        posCode = "SYD";
                    }

                    else if (originCode == "SHJ"||
                            originCode == "AUH" ||
                            originCode == "DWC" ||
                            originCode == "DXB")
                    {
                        posCode = "UAE";
                    }
                    else
                    {
                        posCode = originCode;
                    }

                    pos = await _posAppService.GetPOSByCode(posCode);
                    
                    paymentCreateDto.BookingInfo.PosId = pos.Id;
                
                }

                var oTAUser = await _oTAUserAppService.GetByPOSId(paymentCreateDto.BookingInfo.PosId);
             
                oTAUser.EncryptedPassword = _encryptionAppService.Decrypt(oTAUser.EncryptedPassword);


                var code = location.LocationCode;
                paymentCreateDto.BookingInfo.ContactInfo.CountryName = location.CountryName;
                paymentCreateDto.BookingInfo.ContactInfo.CountryCode = location.CountryCode;

                _logger.LogWarning("before on hold onholdbooking:");

                //Call OnHole Booking
                var onholdbooking = await _onHoldBookingAppService.OnHoldBookingFlightAsync(paymentCreateDto.BookingInfo, oTAUser, code );

                _logger.LogWarning("After on hold {onholdbooking}:", onholdbooking);


                // Check for error in the response
                if (onholdbooking?.Status?.ToLower() == "error")
                {
                    _logger.LogWarning("Error onholdbooking:");

                    var errorMessage = string.Join("; ", onholdbooking.Errors ?? new List<string> { "Unknown error occurred." });
                    return BadRequest(new
                    {
                        status = "error",
                        errors = onholdbooking.Errors,
                    });
                }
                var result = await _paymentAppService.CreateCheckoutSessionAsync(paymentCreateDto.BookingInfo.ContactInfo.Passengers , paymentCreateDto.BookingInfo.Travelers ,paymentCreateDto.PassengerInfo, _stripeSettings, paymentCreateDto.StripeInfo, onholdbooking.PNR, pos.Id, paymentCreateDto.BookingInfo.PaymentAmount);

                _logger.LogWarning("Result onholdbooking {result}:", result);

                var reservationCreateDto = new ReservationCreateDto
                {
                    Pos = pos.POSCode,
                    TransactionId = paymentCreateDto.BookingInfo.TransactionId,
                    PNR = onholdbooking.PNR,
                    PaymentAmount = paymentCreateDto.BookingInfo.PaymentAmount,
                    FlightType = paymentCreateDto.BookingInfo.FlightType,
                    FlightClass = paymentCreateDto.BookingInfo.FlightClass,
                    CheckOutUrl = result,
                    PaymentStatus = "unpaid",
                    ContactInfo = paymentCreateDto.BookingInfo.ContactInfo
                };

                //Store Booking 
                var reservation = await _reservationAppService.Create(reservationCreateDto);
                return Ok(new { checkoutUrl = result, PNR = onholdbooking.PNR  });
            }
            catch (Exception ex) { 
            

                return StatusCode(500, new
                {
                    status = "error",
                    message = "An unexpected error occurred during checkout process.",
                    details = ex.Message 
                });

            }

        }
       
        
        [AllowAnonymous]
        [HttpPost("Webhook")]
        public async Task<IActionResult> StripeWebhook()
        {
            _logger.LogWarning("Stripe Webhook received at {Time}", DateTime.UtcNow);

            try
            {

                HttpContext.Request.EnableBuffering(); 


                var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

                _logger.LogWarning("Received Stripe payload: {Payload}", json);

                HttpContext.Request.Body.Position = 0;

                var stripeSignature = Request.Headers["Stripe-Signature"];
           
                _logger.LogWarning("Stripe-Signature header: {Signature}", stripeSignature);



                await _paymentAppService.HandleStripeWebhookAsync(json, stripeSignature, _stripeSettings);

                _logger.LogWarning("Stripe Webhook processed successfully.");

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing Stripe Webhook.");

                return BadRequest(); 
            }
            
        }
        /*
        [HttpGet("PaymentStatus")]
        public async Task<IActionResult> GetPaymentStatus([FromQuery] string sessionId)
        {
            var paymentInfo = await _paymentAppService.GetPaymentStatusAsync(sessionId);

            if (paymentInfo == null)
                return NotFound();

            return Ok(new
            {
                status = paymentInfo.Status,         
                pnr = paymentInfo.Pnr,               
                bookingStatus = paymentInfo.BookingStatus 
            });
        }
        */




    }
}
