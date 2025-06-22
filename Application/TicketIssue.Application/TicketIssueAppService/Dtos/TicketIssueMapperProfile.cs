using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace TicketIssue.Application.TicketIssueAppService.Dtos
{
    public class TicketIssueMapperProfile : Profile
    {

        public TicketIssueMapperProfile()
        {
            CreateMap<Domain.Models.TicketIssue, TicketIssueGetDto>();
            CreateMap<TicketIssueCreateDto, Domain.Models.TicketIssue>();
            CreateMap<TicketIssueUpdateDto, Domain.Models.TicketIssue>();
        }
    }
}
