using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Loyalty.Application.MemberTravelAgentDetailsAppService.Dto;

namespace Loyalty.Application.SegmentMilesAppService.Dto
{
    public class SegmentMilesMapperProfile : Profile
    {
        public SegmentMilesMapperProfile()
        {
            CreateMap<SegmentMilesCreateDto, Domain.Models.SegmentMiles>();
            CreateMap<SegmentMilesUpdateDto, Domain.Models.SegmentMiles>();
            CreateMap<Domain.Models.SegmentMiles, SegmentMilesGetDto>();
            CreateMap<Domain.Models.SegmentMiles, SegmentMilesGetDto>();

        }
    }
}
