using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using Stripe;
using BookingEngine.Application.Reservation;
using BookingEngine.Application.ReservationInfo.Dtos;

namespace BookingEngine.Host.Controllers
{
    public class ReservationController : BaseController<IReservationAppService, Domain.Models.Reservation, ReservationGetDto, ReservationGetDto, ReservationCreateDto, ReservationUpdateDto, SieveModel>
    {
        public ReservationController(IReservationAppService appService) : base(appService, Servics.BookingEngine)
        {

        }

        [HttpGet("{id}")]
        [AllowAnonymous] 
        public override async Task<ActionResult<ReservationGetDto>> Get(int id)
        {
            var entity = await _appService.Get(id);
            return Ok(entity);

        }
        [HttpGet]
        [AllowAnonymous] 
        public override async Task<ActionResult<ReservationGetDto>> GetAll([FromQuery] SieveModel sieve)
        {
            var entity = await _appService.GetAll(sieve);
            return Ok(entity);

        }


    }
}
