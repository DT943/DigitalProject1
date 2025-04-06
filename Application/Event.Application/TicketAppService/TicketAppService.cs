using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Event.Application.EventAppService.Dtos;
using Event.Application.EventAppService;
using Event.Data.DbContext;
using Infrastructure.Application;
using Sieve.Models;
using Event.Application.TicketAppService.Dtos;
using AutoMapper;
using Event.Application.EventAppService.Validations;
using Microsoft.AspNetCore.Http;
using Sieve.Services;
using Event.Application.TicketAppService.Validations;
using Microsoft.EntityFrameworkCore;

namespace Event.Application.TicketAppService
{
    public class TicketAppService : BaseAppService<EventDbContext, Domain.Models.Ticket, TicketGetAllDto, TicketGetDto, TicketCreateDto, TicketUpdateDto, SieveModel>, ITicketAppService
    {
        public TicketAppService(EventDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, TicketValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {

        }
        protected override IQueryable<Domain.Models.Ticket> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input).Include(x => x.TicketInventory);
        }

    }
}
