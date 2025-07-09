using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookingEngine.Data.DbContext;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;
using Microsoft.EntityFrameworkCore;
using BookingEngine.Application.ReservationInfo.Dtos;
using BookingEngine.Application.ReservationInfo.Validations;

namespace BookingEngine.Application.ReservationInfo
{

    public class ContactInfoAppService : BaseAppService<BookingEngineDbContext, Domain.Models.Contact, ContactInfoGetDto, ContactInfoGetDto, ContactInfoCreateDto, ContactInfoUpdateDto, SieveModel>, IContactInfoAppService
    {
        public ContactInfoAppService(BookingEngineDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, ContactInfoValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
        }


        protected override IQueryable<Domain.Models.Contact> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input)
                .Include(x => x.Passengers).ThenInclude(x => x.Passport)
                .Include(x => x.Passengers).ThenInclude(x => x.Telephone);
        }

    }

}
