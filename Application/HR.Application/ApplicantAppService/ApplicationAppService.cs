using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HR.Application.ApplicationAppService.Dtos;
using HR.Application.ApplicationAppService;
using HR.Data.DbContext;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;
using Microsoft.EntityFrameworkCore;
using HR.Application.CandidateAppService.Validations;

namespace HR.Application.ApplicationAppService
{
    public class ApplicationAppService: BaseAppService<HRDbContext, Domain.Models.Application, ApplicationGetAllDto, ApplicationGetDto, ApplicationCreateDto, ApplicationUpdateDto, SieveModel>, IApplicationAppService
    {
        IHttpContextAccessor _httpContextAccessor;

        HRDbContext _serviceDbContext;

        public ApplicationAppService(HRDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor,ApplicationValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _serviceDbContext = serviceDbContext;

        }
        protected override IQueryable<Domain.Models.Application> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input);

        }
    }
}
