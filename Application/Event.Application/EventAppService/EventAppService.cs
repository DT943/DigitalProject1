using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Event.Application.EventAppService.Dtos;
using Event.Application.EventAppService.Validations;
using Event.Data.DbContext;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace Event.Application.EventAppService
{
    public class EventAppService : BaseAppService<EventDbContext, Domain.Models.Event, EventGetAllDto, EventGetDto, EventCreateDto, EventUpdateDto, SieveModel>, IEventAppService
    {
        public EventAppService(EventDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, EventValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
 
        }

        protected override IQueryable<Domain.Models.Event> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input).Include(x => x.Tickets);
        }

    }
}
