using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace CWCore.Application.POSAppService.Dtos
{
    public class POSMapperProfile : Profile
    {
        public POSMapperProfile()
        {
            CreateMap<Domain.Models.POS, POSGetDto>();
            CreateMap<POSCreateDto, Domain.Models.POS>();
            CreateMap<POSUpdateDto, Domain.Models.POS>();
        }
    }
}
