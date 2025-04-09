using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace HR.Application.JobPostAppService.Dtos
{
    public class JobPostMapperProfile : Profile
    {
        public JobPostMapperProfile()
        {
            CreateMap<JobPostCreateDto, Domain.Models.JobPost>();
            CreateMap<JobPostUpdateDto, Domain.Models.JobPost>();
            CreateMap<Domain.Models.JobPost, JobPostGetDto>();
            CreateMap<Domain.Models.JobPost, JobPostGetAllDto>();

        }
    }
}
