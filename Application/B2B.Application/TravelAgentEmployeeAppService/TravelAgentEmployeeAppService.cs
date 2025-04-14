using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using B2B.Application.TravelAgentOffice.Dto;
using B2B.Application.TravelAgentOffice.Validations;
using B2B.Application.TravelAgentOffice;
using B2B.Data.DbContext;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;
using B2B.Application.TravelAgentEmployeeAppService.Dto;
using B2B.Application.TravelAgentEmployeeAppService.Validations;

namespace B2B.Application.TravelAgentEmployeeAppService
{
    public class TravelAgentEmployeeAppService : BaseAppService<B2BDbContext, Domain.Models.TravelAgentEmployee, TravelAgentEmployeeGetAllDto, TravelAgentEmployeeGetDto, TravelAgentEmployeeCreateDto, TravelAgentEmployeeUpdateDto, SieveModel>, ITravelAgentEmployeeAppService
    {
        public TravelAgentEmployeeAppService(B2BDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, TravelAgentEmployeeValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
        }
    }
}

