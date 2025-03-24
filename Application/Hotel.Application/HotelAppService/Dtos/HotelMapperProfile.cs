using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Hotel.Application.ContactInfoAppService.Dtos;
using Hotel.Application.HotelAppService.Dtos;
using Hotel.Domain.Models;

namespace Hotel.Application.HotelAppService.Dtos
{
    public class HotelMapperProfile : Profile
    {
        public HotelMapperProfile()
        {

            CreateMap<HotelCreateDto, Hotel.Domain.Models.Hotel>()
                .ForMember(dest => dest.Rooms, opt => opt.Ignore())
                .ForMember(dest => dest.HotelGallery, opt => opt.MapFrom(src => src.HotelGallery))
                .ForMember(dest => dest.POS, opt => opt.MapFrom(src => src.POS))
                .ForMember(dest => dest.ContactInfo, opt => opt.MapFrom(src => src.ContactInfo))
                .ForMember(dest => dest.Rank, opt => opt.MapFrom(src => src.Rank));


            CreateMap<CotactInfoCreateDto, ContactInfo>();


            CreateMap<HotelUpdateDto, Hotel.Domain.Models.Hotel>()
                .ForMember(dest => dest.Rooms, opt => opt.Ignore())
                .ForMember(dest => dest.HotelGallery, opt => opt.Ignore());
            CreateMap<CotactInfoUpdateDto, ContactInfo>();


            CreateMap<Domain.Models.Hotel, HotelGetDto>()
                .ForMember(dest => dest.ContactInfo, opt => opt.MapFrom(src => src.ContactInfo)) // if you want to map ContactInfo
                .ForMember(dest => dest.Room, opt => opt.MapFrom(src => src.Rooms))
                .ForMember(dest => dest.HotelGallery, opt => opt.MapFrom(src => src.HotelGallery));


            CreateMap<ContactInfo, ContactInfoGetDto>();

        }
    }
}
