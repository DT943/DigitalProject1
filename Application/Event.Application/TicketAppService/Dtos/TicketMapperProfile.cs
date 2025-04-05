using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Event.Application.EventAppService.Dtos;

namespace Event.Application.TicketAppService.Dtos
{
    public class TicketMapperProfile : Profile
    {
        public TicketMapperProfile()
        {
            CreateMap<Domain.Models.Ticket, TicketGetDto>();
            CreateMap<Domain.Models.Ticket, TicketGetAllDto>();
            CreateMap<TicketCreateDto, Domain.Models.Ticket>();
            CreateMap<TicketUpdateDto, Domain.Models.Ticket>();
        }
    }
}
