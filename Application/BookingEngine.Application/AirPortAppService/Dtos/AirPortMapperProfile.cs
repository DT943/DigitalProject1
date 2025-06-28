using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookingEngine.Domain.Models;

namespace BookingEngine.Application.AirPortAppService.Dtos
{
    public class AirPortMapperProfile : Profile
    {
        public AirPortMapperProfile()
        {

            // For Create
            CreateMap<AirPortCreateDto, AirPort>()
                .ForMember(dest => dest.AirPortTranslations, opt => opt.MapFrom(src => src.AirPortTranslations));

            CreateMap<AirPortTranslationCreateDto, AirPortTranslation>();

            // For Update
            CreateMap<AirPortUpdateDto, AirPort>()
                .ForMember(dest => dest.AirPortTranslations, opt => opt.MapFrom(src => src.AirPortTranslations));

            CreateMap<AirPortTranslationUpdateDto, AirPortTranslation>();

            // For Get (Optional for now)
            CreateMap<AirPort, AirPortGetDto>()
                .ForMember(dest => dest.AirPortTranslations, opt => opt.MapFrom(src => src.AirPortTranslations));

            CreateMap<AirPortTranslation, AirPortTranslationGetDto>();

        }
    }
    
}
