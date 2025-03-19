using AutoMapper;
using Hotel.Application.HotelAppService.Dtos;
using Hotel.Application.RoomAppService.Dtos;

namespace Hotel.Application.RoomAppService.Mapping
{
    public class RoomMappingProfile : Profile
    {
        public RoomMappingProfile()
        {
            CreateMap<Domain.Models.Room, RoomOutputDto>();
            CreateMap<RoomCreateDto, Domain.Models.Room>();
            CreateMap<RoomUpdateDto, Domain.Models.Room>();
        }
    }
}