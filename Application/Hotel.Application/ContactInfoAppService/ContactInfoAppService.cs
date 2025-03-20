using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Hotel.Application.ContactInfoAppService.Validations;
using Hotel.Application.HotelAppService.Dtos;
using Hotel.Application.HotelAppService;
using Hotel.Application.HotelAppService.Validations;
using Hotel.Data.DbContext;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;
using Hotel.Application.ContactInfoAppService.Dtos;

namespace Hotel.Application.ContactInfoAppService
{
    class ContactInfoAppService : BaseAppService<HotelDbContext, Domain.Models.ContactInfo, ContactInfoGetDto, ContactInfoGetDto, CotactInfoCreateDto, CotactInfoUpdateDto, SieveModel>, IContactInfoAppService
    {
        IHttpContextAccessor _httpContextAccessor;
        HotelDbContext _serviceDbContext;

        public ContactInfoAppService(HotelDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, ContactInfoValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _serviceDbContext = serviceDbContext;
        }
        protected override IQueryable<Domain.Models.ContactInfo> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input);
        }

    }
}
