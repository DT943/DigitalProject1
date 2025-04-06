using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Event.Application.TicketAppService.Dtos;

namespace Event.Application.TicketInventoryAppService.Dtos
{
    public class TicketInventoryMapperProfile : Profile
    {
        public TicketInventoryMapperProfile()
        {
            CreateMap<Domain.Models.TicketInventory, TicketInventoryGetDto>();
            CreateMap<Domain.Models.TicketInventory, TicketInventoryGetAllDto>();
            CreateMap<TicketInventoryCreateDto, Domain.Models.TicketInventory>();
            CreateMap<TicketInventoryUpdateDto, Domain.Models.TicketInventory>();
        }
    }
}
