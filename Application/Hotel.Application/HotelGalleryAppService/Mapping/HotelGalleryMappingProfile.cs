using AutoMapper;
using Hotel.Application.HotelGalleryAppService.Dtos;

namespace Hotel.Application.HotelGalleryAppService.Mapping
{
    public class HotelGalleryMappingProfile : Profile
    {
        public HotelGalleryMappingProfile()
        {
            CreateMap<Domain.Models.HotelGallery, HotelGalleryOutputDto>();
            CreateMap<HotelGalleryCreateDto, Domain.Models.HotelGallery>();
            CreateMap<HotelGalleryUpdateDto, Domain.Models.HotelGallery>();
        }
    }
}