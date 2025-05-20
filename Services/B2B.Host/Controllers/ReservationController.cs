using Authentication.Application;
using B2B.Application.TravelAgentApplicationAppService;
using B2B.Application.TravelAgentEmployeeAppService.Dto;
using B2B.Application.TravelAgentEmployeeAppService.Validations;
using B2B.Application.TravelAgentEmployeeAppService;
using B2B.Application.TravelAgentOffice;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using B2B.Application.ReservationAppService;
using B2B.Application.ReservationAppService.Dto;
using B2B.Application.ReservationAppService.Validations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace B2B.Host.Controllers
{
    [Authorize]
    public class ReservationController : BaseController<IReservationAppService, Domain.Models.Reservation, ReservationGetDto, ReservationGetDto, ReservationCreateDto, ReservationUpdateDto, SieveModel>
    {


        public ReservationController(IReservationAppService appService) : base(appService, Servics.B2B)
        {
       

        }

 
        public override async Task<ActionResult<ReservationGetDto>> Create(ReservationCreateDto dto)
        {
            var entity = await _appService.Create(dto);
            return Ok(entity);
        }
        public override async Task<ActionResult<ReservationGetDto>> GetAll([FromQuery] SieveModel sieve)
        {
            var user = HttpContext.User; 
            var entity = await _appService.GetAll(sieve);
            return Ok(entity);
        }
    }
}
