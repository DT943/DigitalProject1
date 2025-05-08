using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Event.Application.EventAppService.Dtos;
using Infrastructure.Application;
using Sieve.Models;

namespace Event.Application.EventAppService
{
    public interface IEventAppService : IBaseAppService<EventGetAllDto, EventGetDto, EventCreateDto, EventUpdateDto, SieveModel>
    {
    }
}
