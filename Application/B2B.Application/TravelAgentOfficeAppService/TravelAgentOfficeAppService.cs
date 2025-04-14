using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using B2B.Application.TravelAgentOffice.Dto;
using B2B.Application.TravelAgentOffice.Validations;
using B2B.Data.DbContext;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;

namespace B2B.Application.TravelAgentOffice
{
    public class TravelAgentOfficeAppService : BaseAppService<B2BDbContext, Domain.Models.TravelAgentOffice, TravelAgentOfficeGetAllDto, TravelAgentOfficeGetDto, TravelAgentOfficeCreateDto, TravelAgentOfficeUpdateDto, SieveModel>, ITravelAgentOfficeAppService
    {
        public TravelAgentOfficeAppService(B2BDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, TravelAgentOfficeValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
        }
    }
}
