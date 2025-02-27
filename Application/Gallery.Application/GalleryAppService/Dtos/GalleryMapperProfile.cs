using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Gallery.Application.GalleryAppService.Dtos
{
    public class GalleryMapperProfile : Profile
    {
        public GalleryMapperProfile()
        {
            CreateMap<Domain.Models.Gallery, GalleryGetDto>();
            CreateMap<GalleryCreateDto, Domain.Models.Gallery>();
            CreateMap<GalleryUpdateDto, Domain.Models.Gallery>();
        }
    }

}
