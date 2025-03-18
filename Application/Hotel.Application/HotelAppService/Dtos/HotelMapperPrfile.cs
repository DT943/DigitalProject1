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
        }
    }
}
