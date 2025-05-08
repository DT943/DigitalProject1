using Event.Application.EventAppService.Dtos;
using Event.Application.EventAppService;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using Event.Application.TicketAppService;
using Event.Application.TicketAppService.Dtos;

namespace Event.Host.Controllers
{
    public class TicketController : BaseController<ITicketAppService, Domain.Models.Ticket, TicketGetAllDto, TicketGetDto, TicketCreateDto, TicketUpdateDto, SieveModel>
    {
        ITicketAppService _contractAppService;
        public TicketController(ITicketAppService contractAppService) : base(contractAppService, Servics.EVENT)
        {
            _contractAppService = contractAppService;
        }
    }
}
