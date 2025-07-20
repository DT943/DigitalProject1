using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookingEngine.Application.AmenitiesAppService.Dtos;
using BookingEngine.Application.AmenitiesAppService.Validations;
using BookingEngine.Application.AuditAppService.Validations;
using BookingEngine.Data.DbContext;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;

namespace BookingEngine.Application.AmenitiesAppService
{
    public class AmenitiesAppService :BaseAppService<BookingEngineDbContext, Domain.Models.Amenity, AmenityGetDto, AmenityGetDto, AmenityCreateDto, AmenityUpdateDto, SieveModel>, IAmenitiesAppService
    {
        public AmenitiesAppService(BookingEngineDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, AmenitiesValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
        }

    }
}
