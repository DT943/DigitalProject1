using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Hotel.Application.ContactInfoAppService.Dtos;
using Hotel.Application.ContactInfoAppService.Validations;
using Hotel.Application.ContactInfoAppService;
using Hotel.Data.DbContext;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;
using Hotel.Application.ContractAppService.Dtos;
using Hotel.Application.ContractAppService.Validations;

namespace Hotel.Application.ContractAppService
{
    public class ContractAppService : BaseAppService<HotelDbContext, Domain.Models.Contract, ContractGetDto, ContractGetDto, ContractCreateDto, ContractUpdateDto, SieveModel>, IContractAppService
    {
        IHttpContextAccessor _httpContextAccessor;
        HotelDbContext _serviceDbContext;

        public ContractAppService(HotelDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, ContractValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _serviceDbContext = serviceDbContext;
        }
        protected override IQueryable<Domain.Models.Contract> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input);
        }

    }
}
