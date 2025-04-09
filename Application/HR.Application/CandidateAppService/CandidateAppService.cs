using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HR.Application.JobPostAppService.Dtos;
using HR.Application.JobPostAppService.Validations;
using HR.Application.JobPostAppService;
using HR.Data.DbContext;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;
using HR.Application.CandidateAppService.Dtos;
using HR.Application.CandidateAppService.Validations;

namespace HR.Application.CandidateAppService
{
    public class CandidateAppService : BaseAppService<HRDbContext, Domain.Models.Candidate, CandidateGetAllDto, CandidateGetDto, CandidateCreateDto, CandidateUpdateDto, SieveModel>, ICandidateAppService
    {
        public CandidateAppService(HRDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, CandidateValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
        }
    }
}

