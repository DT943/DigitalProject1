using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using TicketIssue.Application.TicketIssueAppService;
using TicketIssue.Application.TicketIssueAppService.Dtos;
using static Infrastructure.Domain.Consts;

namespace TicketIssue.Host.Controllers
{
    [Authorize]
    public class TicketIssueController : BaseController<ITicketIssueAppService, Domain.Models.TicketIssue, TicketIssueGetDto, TicketIssueGetDto, TicketIssueCreateDto, TicketIssueUpdateDto, SieveModel>
    {
        public TicketIssueController(ITicketIssueAppService appService) : base(appService, Servics.TicketIssue)
        {

        }
    }
}
