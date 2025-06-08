using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Loyalty.Application.SegmentMilesAppService.Dto;

namespace Loyalty.Application.SegmentMilesRedemption.Dto
{
    public class SegmentMilesRedemptionMapperProfile : Profile
    {
        public SegmentMilesRedemptionMapperProfile()
        {
            CreateMap<SegmentMilesRedemptionCreateDto, Domain.Models.SegmentMilesRedemption>();
            CreateMap<SegmentMilesRedemptionUpdateDto, Domain.Models.SegmentMilesRedemption>();
            CreateMap<Domain.Models.SegmentMilesRedemption, SegmentMilesRedemptionGetDto>();
 
        }
    }
}
