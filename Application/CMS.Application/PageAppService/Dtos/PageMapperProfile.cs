using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CMS.Application.PageAppService.Dtos
{
    public class PageMapperProfile : Profile
    {
        public PageMapperProfile()
        {
            CreateMap<Domain.Models.Page, PageGetDto>();
            CreateMap<PageCreateDto, Domain.Models.Page>();
            CreateMap<PageUpdateDto, Domain.Models.Page>().ForMember(dest => dest.Segments, opt => opt.Ignore());
        }
    }
}
