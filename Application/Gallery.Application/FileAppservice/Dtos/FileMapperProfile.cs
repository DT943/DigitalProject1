using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gallery.Application.GalleryAppService.Dtos;

namespace Gallery.Application.FileAppservice.Dtos
{
    public class FileMapperProfile : Profile
    {
        public FileMapperProfile()
        {
            CreateMap<Domain.Models.File, FileGetDto>();


            CreateMap<FileGetDto, FileWithOCRGetDto>();
               // .ForMember(dest => dest.OcrString, opt => opt.MapFrom(src => ""));

            CreateMap<FileCreateDto, Domain.Models.File>();
            CreateMap<FileUpdateDto, Domain.Models.File>();
        }
    }
}
