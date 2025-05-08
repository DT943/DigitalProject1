using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Event.Application.TicketAppService.Dtos;
using Event.Application.TicketInventoryAppService.Dtos;
using Infrastructure.Application;
using Sieve.Models;

namespace Event.Application.TicketInventoryAppService
{
    public interface ITicketInventoryAppService : IBaseAppService<TicketInventoryGetAllDto, TicketInventoryGetDto, TicketInventoryCreateDto, TicketInventoryUpdateDto, SieveModel>
    {
        public  Task<List<TicketInventoryGetDto>> BuyTickets(TicketInventoryBuyDto TIB);
    }
}
