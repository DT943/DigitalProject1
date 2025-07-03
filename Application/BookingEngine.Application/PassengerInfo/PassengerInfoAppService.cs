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

namespace BookingEngine.Application.PassengerInfo
{
    public class PassengerInfoAppService : BaseAppService<BookingEngineDbContext, Domain.Models.PassengerInfo, PassengerInfoGetDto, PassengerInfoGetDto, PassengerInfoCreateDto, PassengerInfoUpdateDto, SieveModel>, IPassengerInfoAppService
    {
        public PassengerInfoAppService(BookingEngineDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, PassengerInfoValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
        }
    }
    
}
