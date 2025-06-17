using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HR.Application.JobPostAppService.Dtos;
using HR.Domain.Models;

namespace HR.Application.CandidateAppService.Dtos
{
    public class CandidateMapperProfile : Profile
    {
        public CandidateMapperProfile()
        {
            CreateMap<CandidateCreateDto, Candidate>();

            CreateMap<CandidateUpdateDto, Candidate>();


            CreateMap<EducationItemDto, EducationItem>();

            CreateMap<EducationItemUpdateDto, EducationItem>();

            CreateMap<EducationItem, EducationItemDto>();



            CreateMap<ProjectItemDto, ProjectItem>();

            CreateMap<ProjectItemUpdateDto, ProjectItem>();

            CreateMap<ProjectItem, ProjectItemDto>();



            CreateMap<ExperienceItemUpdateDto, ExperienceItem>();

            CreateMap<ExperienceItemDto, ExperienceItem>();

            CreateMap<ExperienceItem, ExperienceItemDto>();



            CreateMap<Candidate, CandidateGetDto>();

            CreateMap<Candidate, CandidateGetAllDto>();
        }

    }
}
