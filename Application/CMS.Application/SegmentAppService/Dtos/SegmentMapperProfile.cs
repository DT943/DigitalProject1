using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CMS.Application.PageAppService.Dtos;

namespace CMS.Application.SegmentAppService.Dtos
{
    public class SegmentMapperProfile : Profile
    {
        public SegmentMapperProfile()
        {
            CreateMap<Domain.Models.Segment, SegmentGetDto>();
            CreateMap<SegmentCreateDto, Domain.Models.Segment>();
            CreateMap<SegmentUpdateDto, Domain.Models.Segment>().ForMember(dest => dest.Components, opt => opt.Ignore()); ;
        }
    }
}
