using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookingEngine.Application.AirPortAppService.Dtos;
using BookingEngine.Domain.Models;

namespace BookingEngine.Application.POSAppService.Dtos
{
    public class POSMapperProfile : Profile
    {
        public POSMapperProfile()
        {

            // For Create
            CreateMap<POSCreateDto, POS>()
                .ForMember(dest => dest.POSTranslations, opt => opt.MapFrom(src => src.POSTranslations));

            CreateMap<POSTranslationCreateDto, POSTranslation>();

            // For Update
            CreateMap<POSUpdateDto, POS>()
                .ForMember(dest => dest.POSTranslations, opt => opt.MapFrom(src => src.POSTranslations));

            CreateMap<POSTranslationUpdateDto, POSTranslation>();

            // For Get (Optional for now)
            CreateMap<POS, POSGetDto>()
                .ForMember(dest => dest.POSTranslations, opt => opt.MapFrom(src => src.POSTranslations));

            CreateMap<POSTranslation, POSTranslationGetDto>();

        }
    }

}
