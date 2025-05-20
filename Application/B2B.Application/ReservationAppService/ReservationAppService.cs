using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using B2B.Application.TravelAgentApplicationAppService.Dto;
using B2B.Application.TravelAgentApplicationAppService.Validations;
using B2B.Application.TravelAgentApplicationAppService;
using B2B.Data.DbContext;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;
using B2B.Application.ReservationAppService.Dto;
using B2B.Application.ReservationAppService.Validations;
using Microsoft.EntityFrameworkCore;

namespace B2B.Application.ReservationAppService
{
    public class ReservationAppService : BaseAppService<B2BDbContext, Domain.Models.Reservation, ReservationGetDto, ReservationGetDto, ReservationCreateDto, ReservationUpdateDto, SieveModel>, IReservationAppService
    {
        public ReservationAppService(B2BDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, ReservationValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
        }


        protected override IQueryable<Domain.Models.Reservation> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input)
                .Include(x => x.Segments)
                .Include(x => x.Passengers)
                .Include(x=>x.ContactInfo)
                .Include(x => x.PNRDetails);
        }
    }
}