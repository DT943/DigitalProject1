using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using B2B.Application.TravelAgentEmployeeAppService.Dto;
using B2B.Application.TravelAgentEmployeeAppService.Validations;
using B2B.Application.TravelAgentEmployeeAppService;
using B2B.Data.DbContext;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;
using B2B.Application.TravelAgentApplicationAppService.Dto;
using B2B.Application.TravelAgentApplicationAppService.Validations;
using Microsoft.EntityFrameworkCore;

namespace B2B.Application.TravelAgentApplicationAppService
{
    public class TravelAgentApplicationAppService : BaseAppService<B2BDbContext, Domain.Models.TravelAgentApplication, TravelAgentApplicationGetAllDto, TravelAgentApplicationGetDto, TravelAgentApplicationCreateDto, TravelAgentApplicationUpdateDto, SieveModel>, ITravelAgentApplicationAppService
    {
        public TravelAgentApplicationAppService(B2BDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, TravelAgentApplicationValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
        }
        public async Task<TravelAgentApplicationGetDto> GetByCode(string code)
        {

            var travelAgent = await _serviceDbContext.TravelAgentApplications.Where(x => x.Code == code).ToListAsync();


            return _mapper.Map<TravelAgentApplicationGetDto>(travelAgent);
        }


        protected override IQueryable<Domain.Models.TravelAgentApplication> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input).Include(x => x.Employees);
        }
    }
}