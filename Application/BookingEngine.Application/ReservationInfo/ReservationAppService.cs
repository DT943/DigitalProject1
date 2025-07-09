using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookingEngine.Application.OTAUserAppService.Dtos;
using BookingEngine.Application.OTAUserAppService.Validations;
using BookingEngine.Application.OTAUserAppService;
using BookingEngine.Data.DbContext;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;
using BookingEngine.Application.PassengerInfo.Dtos;
using BookingEngine.Application.PassengerInfo.Validations;
using BookingEngine.Application.ReservationInfo.Dtos;
using Microsoft.EntityFrameworkCore;
using BookingEngine.Application.ReservationInfo.Validations;

namespace BookingEngine.Application.Reservation
{
    public class ReservationAppService : BaseAppService<BookingEngineDbContext, Domain.Models.Reservation, ReservationGetDto, ReservationGetDto, ReservationCreateDto, ReservationUpdateDto, SieveModel>, IReservationAppService
    {
        public ReservationAppService(BookingEngineDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, ContactInfoValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {

        }
        protected override IQueryable<Domain.Models.Reservation> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input)
                .Include(p => p.ContactInfo)
                    .ThenInclude(p => p.Passengers)
                    .ThenInclude(p => p.Telephone)
                .Include(p => p.ContactInfo)
                    .ThenInclude(p => p.Passengers)
                    .ThenInclude(p => p.Passport);
        }

    }

}
