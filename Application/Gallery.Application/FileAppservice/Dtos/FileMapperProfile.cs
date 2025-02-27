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
            CreateMap<FileCreateDto, Domain.Models.File>();
            CreateMap<FileUpdateDto, Domain.Models.File>();
        }
    }
}
