using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Event.Application.EventAppService.Dtos;
using Event.Application.TicketAppService.Dtos;
using Infrastructure.Application;
using Sieve.Models;

namespace Event.Application.TicketAppService
{
    public interface ITicketAppService : IBaseAppService<TicketGetAllDto, TicketGetDto, TicketCreateDto, TicketUpdateDto, SieveModel>
    {
    }
}
