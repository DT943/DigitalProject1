using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HR.Application.JobPostAppService.Dtos;

namespace HR.Application.CandidateAppService.Dtos
{
    public class CandidateMapperProfile : Profile
    {
        public CandidateMapperProfile()
        {
            CreateMap<CandidateCreateDto, Domain.Models.JobPost>();
            CreateMap<CandidateUpdateDto, Domain.Models.JobPost>();
            CreateMap<Domain.Models.JobPost, CandidateGetDto>();
            CreateMap<Domain.Models.JobPost, JobPostGetAllDto>();
        }
    }
}
