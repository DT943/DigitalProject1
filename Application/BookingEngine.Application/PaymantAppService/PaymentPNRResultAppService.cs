using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookingEngine.Application.PaymantAppService.Dtos;
using BookingEngine.Application.PaymantAppService.Validations;
using BookingEngine.Data.DbContext;
using Infrastructure.Application;
using Infrastructure.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace BookingEngine.Application.PaymantAppService
{
    public class PaymentPNRResultAppService :BaseAppService<BookingEngineDbContext, Domain.Models.PaymentPNRResult, PaymentPNRResultGetDto, PaymentPNRResultGetDto, PaymentPNRResultCreateDto, PaymentPNRResultUpdateDto, SieveModel>, IPaymentPNRResultAppService
    {
        public PaymentPNRResultAppService(BookingEngineDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, PaymentPNRResultValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {

        }
        public async Task<PaymentPNRResultGetDto> GetBySessionId(string sessionId)
        {
            var result = await QueryExcuter(null).FirstOrDefaultAsync(x => x.SessionId.Equals(sessionId));
            if (result == null)
            {
                throw new EntityNotFoundException(typeof(PaymentPNRResultGetDto).Name, sessionId ?? "");
            }    
            return await Task.FromResult(_mapper.Map<PaymentPNRResultGetDto>(result));
        }
        protected override IQueryable<Domain.Models.PaymentPNRResult> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input)
                .Include(x => x.ETickets)
                .Include(x => x.Taxes)
                .Include(x => x.Fees)
                .Include(x => x.Passengers)
                .Include(x => x.Segments)
                .Include(x => x.Contact);
        }

    }
}


