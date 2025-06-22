using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application;
using Sieve.Models;
using TicketIssue.Application.TicketIssueAppService.Dtos;

namespace TicketIssue.Application.TicketIssueAppService
{
    public interface ITicketIssueAppService : IBaseAppService<TicketIssueGetDto, TicketIssueGetDto, TicketIssueCreateDto, TicketIssueUpdateDto, SieveModel>
    {
    }
}
