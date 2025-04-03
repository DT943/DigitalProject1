using Event.Application.EventAppService;
using Event.Application.EventAppService.Dtos;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;

namespace Event.Host.Controllers
{
    public class EventController : BaseController<IEventAppService, Domain.Models.Event, EventGetAllDto, EventGetDto, EventCreateDto, EventUpdateDto, SieveModel>
    {
        IEventAppService _contractAppService;
        public EventController(IEventAppService contractAppService) : base(contractAppService, Servics.EVENT)
        {
            _contractAppService = contractAppService;
        }
    }
}
