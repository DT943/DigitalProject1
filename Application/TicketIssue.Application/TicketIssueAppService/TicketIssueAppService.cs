using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;
using TicketIssue.Application.TicketIssueAppService.Dtos;
using TicketIssue.Application.TicketIssueAppService.Validations;
using TicketIssue.Data.DbContext;

namespace TicketIssue.Application.TicketIssueAppService
{
    public class TicketIssueAppService : BaseAppService<TicketIssueDbContext, Domain.Models.TicketIssue, TicketIssueGetDto, TicketIssueGetDto, TicketIssueCreateDto, TicketIssueUpdateDto, SieveModel>, ITicketIssueAppService
    {
        IHttpContextAccessor _httpContextAccessor;
        TicketIssueDbContext _serviceDbContext;
        public TicketIssueAppService(TicketIssueDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, TicketIssueValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _serviceDbContext = serviceDbContext;
        }

        protected override IQueryable<Domain.Models.TicketIssue> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input);
        }
    }
}
