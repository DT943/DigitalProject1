using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CWCore.Domain.Models;

namespace CWCore.Application.LanguageAppService.Dtos
{
    public class LanguageMapperProfile : Profile
    {
        public LanguageMapperProfile() {

            CreateMap<Language, LanguageGetDto>();
            CreateMap<LanguageCreateDto, Language>();
            CreateMap<LanguageUpdateDto, Language>();
        }


    }
}
