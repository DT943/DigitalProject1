using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Hotel.Application.HotelAppService.Dtos;

namespace Hotel.Application.HotelAppService.Dtos
{
    public class HotelMapperProfile : Profile
    {
        public HotelMapperProfile()
        {
            CreateMap<Hotel.Domain.Models.Hotel, HotelGetDto>();
            CreateMap<HotelCreateDto, Hotel.Domain.Models.Hotel>();
            CreateMap<HotelUpdateDto, Hotel.Domain.Models.Hotel>();
            CreateMap<HotelGetDto, HotelGetDetailsDto>()
                .ForMember(dest => dest.Rooms, opt => opt.Ignore()) 
                .ForMember(dest => dest.HotelGallery, opt => opt.Ignore()) 
                .ForMember(dest => dest.POS, opt => opt.MapFrom(src => src.POS)); 

        }
    }
}
