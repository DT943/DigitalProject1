using BookingEngine.Application.OTAUserAppService.Dtos;
using BookingEngine.Application.OTAUserAppService;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using BookingEngine.Application.PassengerInfo;
using BookingEngine.Application.PassengerInfo.Dtos;
using BookingEngine.Application.AirPortAppService.Dtos;
using Microsoft.AspNetCore.Authorization;
using BookingEngine.Application.ReservationInfo.Dtos;
using BookingEngine.Application.ReservationInfo;
using Stripe;

namespace BookingEngine.Host.Controllers
{
    public class ContactController : BaseController<IContactInfoAppService, Domain.Models.Contact, ContactInfoGetDto, ContactInfoGetDto, ContactInfoCreateDto, ContactInfoUpdateDto, SieveModel>
    {
        public ContactController(IContactInfoAppService appService) : base(appService, Servics.BookingEngine)
        {
        }

        [HttpPost("CreateListPassenger")]
        [AllowAnonymous] 
        public async Task<ActionResult<ContactInfoGetDto> >CreateListPassenger (ContactInfoCreateDto contactInfoCreateDto)
        {
            try
            {
                var results = new List<PassengerInfoGetDto>();

                var contact = await _appService.Create(contactInfoCreateDto);
                return Ok(contact);

            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }

    }
}
