using BookingEngine.Application.PaymantAppService;
using BookingEngine.Application.PaymantAppService.Dtos;
using BookingEngine.Application.Reservation;
using BookingEngine.Application.WrappingAppService.WrappingBookingAppService;
using BookingEngine.Application.WrappingAppService.WrappingBookingAppService.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
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

        private readonly ILogger<PaymentController> _logger;


        public PaymentController(IPaymentAppService paymentAppService, IWrappingOnHoldBookingAppService onHoldBookingAppService, IReservationAppService reservationAppService, IOptions<StripeSettingsDto> stripeOptions, ILogger<PaymentController> logger)
        {
            _paymentAppService = paymentAppService;
            _stripeSettings =  stripeOptions.Value;
            _onHoldBookingAppService = onHoldBookingAppService;
            _reservationAppService = reservationAppService;
            _logger = logger;

        }


        [HttpPost("Checkout")]
        public async Task<IActionResult> CreateCheckout(PaymentCreateDto paymentCreateDto)
        {
                        
            //Call OnHole Booking
            //var onholdbooking = await _onHoldBookingAppService.OnHoldBookingFlightAsync(paymentCreateDto.BookingInfo);


            // Check for error in the response
            //if (onholdbooking?.Status?.ToLower() == "error")
            //{
              //  var errorMessage = string.Join("; ", onholdbooking.Errors ?? new List<string> { "Unknown error occurred." });
               // return BadRequest(new
                //{
                 //   status = "error",
                  //  errors = onholdbooking.Errors,
                //});
            //}


            var result = await _paymentAppService.CreateCheckoutSessionAsync(_stripeSettings, paymentCreateDto.StripeInfo, "onholdbooking.PNR");

            return Ok(new { checkoutUrl = result, PNR = "onholdbooking.PNR" });

        }
       
        
        [AllowAnonymous]
        [HttpPost("Webhook")]
        public async Task<IActionResult> StripeWebhook()
        {

            HttpContext.Request.EnableBuffering(); 


            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();


            HttpContext.Request.Body.Position = 0;

            var stripeSignature = Request.Headers["Stripe-Signature"];

            try
            {

                await _paymentAppService.HandleStripeWebhookAsync(json, stripeSignature, _stripeSettings);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(); // Stripe will retry if you return 400
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



/*
[HttpGet("success")]
public IActionResult Success()
{
    return Ok("Payment was cancelled.");
}
// Optional: Cancel endpoint
[HttpGet("cancel")]
public IActionResult Cancel()
{
    return Ok("Payment was cancelled.");
}
*/