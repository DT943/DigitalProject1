using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HR.Domain.Models;

namespace HR.Application.JobPostAppService.Dtos
{
    public class JobPostMapperProfile : Profile
    {
        public JobPostMapperProfile()
        {
            CreateMap<JobPostCreateDto, JobPost>();

            CreateMap<JobPostUpdateDto, JobPost>();

            CreateMap<JobPost, JobPostGetDto>();

            CreateMap<JobPost, JobPostGetAllDto>();
        }
    }
}
