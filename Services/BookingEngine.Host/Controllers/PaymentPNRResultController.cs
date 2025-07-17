using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using Stripe;
using BookingEngine.Application.PaymantAppService.Dtos;
using BookingEngine.Application.PaymantAppService;
using BookingEngine.Domain.Models;

namespace BookingEngine.Host.Controllers
{
    public class PaymentPNRResultController : BaseController<IPaymentPNRResultAppService, Domain.Models.PaymentPNRResult, PaymentPNRResultGetDto, PaymentPNRResultGetDto, PaymentPNRResultCreateDto, PaymentPNRResultUpdateDto, SieveModel>
    {
        public PaymentPNRResultController(IPaymentPNRResultAppService appService) : base(appService, Servics.BookingEngine)
        {

        }


        [HttpGet("GetBySessionId")]
        [AllowAnonymous] // Allow access without authentication
        public async Task<ActionResult<PaymentPNRResultGetDto>> GetBySessionId([FromHeader] string sessionId)
        {
            if (sessionId == null) {
                return BadRequest("SessionId Required");
            }
            var entity = await _appService.GetBySessionId(sessionId);
            return Ok(entity);

        }


    }
}
