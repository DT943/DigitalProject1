using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CMS.Application.AirportsAppService.Dto;
using CMS.Application.AirportsAppService.Validations;
using CMS.Data.DbContext;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;

namespace CMS.Application.AirportsAppService
{
    public class AirportsAppService : BaseAppService<CMSDbContext, Domain.Models.Airports, AirportsGetDto, AirportsGetDto, AirportsCreateDto, AirportsUpdateDto, SieveModel>, IAirportsAppService
    {
        
        public AirportsAppService(CMSDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, AirportsValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {


        }

        protected override IQueryable<Domain.Models.Airports> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input);
        }
    }
}
