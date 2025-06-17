using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using HR.Application.PositionAppService.Dtos;
using HR.Application.PositionAppService.Validations;
using HR.Data.DbContext;
using Infrastructure.Application;
using Infrastructure.Application.Validations;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;

namespace HR.Application.PositionAppService
{
    public class PositionAppService : BaseAppService<HRDbContext, Domain.Models.Position, PositionGetAllDto, PositionGetDto, PositionCreateDto, PositionUpdateDto, SieveModel>, IPositionAppService
    {
        IHttpContextAccessor _httpContextAccessor;

        HRDbContext _serviceDbContext;

        public PositionAppService(HRDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, PositionValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _serviceDbContext = serviceDbContext;
        }
        protected override IQueryable<Domain.Models.Position> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input);
        }
    }
}
