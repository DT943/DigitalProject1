using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using HR.Application.JobPostAppService.Dtos;
using HR.Application.JobPostAppService.Validations;
using HR.Data.DbContext;
using Infrastructure.Application;
using Infrastructure.Application.Validations;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;

namespace HR.Application.JobPostAppService
{
    public class JobPostAppService : BaseAppService<HRDbContext, Domain.Models.JobPost, JobPostGetAllDto, JobPostGetDto, JobPostCreateDto, JobPostUpdateDto, SieveModel>, IJobPostAppService
    {
        public JobPostAppService(HRDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, JobPostValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
        }
    }
}
