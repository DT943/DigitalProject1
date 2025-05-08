using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Event.Application.EventAppService.Dtos
{
    public class EventMapperProfile : Profile
    {
        public EventMapperProfile()
        {
            CreateMap<Domain.Models.Event, EventGetDto>();
            CreateMap<Domain.Models.Event, EventGetAllDto>();

            CreateMap<EventCreateDto, Domain.Models.Event>();
            CreateMap<EventUpdateDto, Domain.Models.Event>();
 
        }
    }
}
