using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HR.Application.CandidateAppService.Dtos;
using HR.Application.CandidateAppService.Validations;
using HR.Application.CandidateAppService;
using HR.Data.DbContext;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;
using HR.Application.JobPostAppService.Validations;
using Microsoft.EntityFrameworkCore;

namespace HR.Application.CandidateAppService
{
    public class CandidateAppService: BaseAppService<HRDbContext, Domain.Models.Candidate, CandidateGetAllDto, CandidateGetDto, CandidateCreateDto, CandidateUpdateDto, SieveModel>, ICandidateAppService
    {
        IHttpContextAccessor _httpContextAccessor;

        HRDbContext _serviceDbContext;

        public CandidateAppService(HRDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, CandidateValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _serviceDbContext = serviceDbContext;

        }
        protected override IQueryable<Domain.Models.Candidate> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input);

        }
    }
}
