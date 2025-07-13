using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookingEngine.Application.AuditAppService.Dtos;
using BookingEngine.Application.AuditAppService.Validations;
using BookingEngine.Data.DbContext;
using BookingEngine.Domain.Models;
using Infrastructure.Application;
using Infrastructure.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace BookingEngine.Application.AuditAppService
{
    public class InquirePNRRequestAppService : BaseAppService<BookingEngineDbContext, Domain.Models.InquirePNR, InquirePNRAuditWithIPGetDto, InquirePNRAuditWithIPGetDto, InquirePNRAuditCreateDto, InquirePNRUpdateDto, SieveModel>, IInquirePNRRequestAppService
    {
        public InquirePNRRequestAppService(BookingEngineDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, AuditValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
        }



        protected override IQueryable<Domain.Models.InquirePNR> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input)
                .Include(x => x.inquirePNRResponse).ThenInclude(x => x.Segments)
                .Include(x => x.inquirePNRResponse).ThenInclude(x => x.Fare)
                .Include(x => x.inquirePNRResponse).ThenInclude(x => x.Fare).ThenInclude(x=> x.Fees)
                .Include(x => x.inquirePNRResponse).ThenInclude(x => x.Fare).ThenInclude(x => x.Taxes)
                .Include(x => x.inquirePNRResponse).ThenInclude(x => x.Passengers)
                .Include(x => x.inquirePNRResponse).ThenInclude(x => x.Passengers).ThenInclude(x=>x.ETicketInfo)
                .Include(x => x.inquirePNRResponse).ThenInclude(x => x.ContactInfo)
                .Include(x => x.inquirePNRResponse).ThenInclude(x => x.PassengerCounts);
        }
    }
}
