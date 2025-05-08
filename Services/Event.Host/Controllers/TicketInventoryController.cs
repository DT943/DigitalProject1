using Event.Application.TicketAppService.Dtos;
using Event.Application.TicketAppService;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using Event.Application.TicketInventoryAppService;
using Event.Application.TicketInventoryAppService.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace Event.Host.Controllers
{
    [Authorize]
    public class TicketInventoryController : BaseController<ITicketInventoryAppService, Domain.Models.TicketInventory, TicketInventoryGetAllDto, TicketInventoryGetDto, TicketInventoryCreateDto, TicketInventoryUpdateDto, SieveModel>
    {
        ITicketInventoryAppService _contractAppService;
        public TicketInventoryController(ITicketInventoryAppService contractAppService) : base(contractAppService, Servics.EVENT)
        {
            _contractAppService = contractAppService;
        }

        [HttpPost("buytickets")]
        public async Task<ActionResult<List<TicketInventoryGetDto>>> BuyTickets(TicketInventoryBuyDto TIB)
        {
            var user = HttpContext.User;

            if (!UserHasPermission("Admin", "Manager", "Supervisor", "Officer"))
            {
                return Forbid();
            }

            return await _contractAppService.BuyTickets(TIB);
        }
    }
}
