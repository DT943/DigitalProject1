using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookingEngine.Application.AmenitiesAppService.Dtos;
using BookingEngine.Application.AmenitiesAppService.Validations;
using BookingEngine.Application.AmenitiesAppService;
using BookingEngine.Data.DbContext;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;
using BookingEngine.Application.LocationAppService.Dtos;
using BookingEngine.Application.LocationAppService.Validations;
using BookingEngine.Application.OTAUserAppService.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BookingEngine.Application.LocationAppService
{

    public class LocationAppService : BaseAppService<BookingEngineDbContext, Domain.Models.Location, LocationGetDto, LocationGetDto, LocationCreateDto, LocationUpdateDto, SieveModel>, ILocationAppService
    {
        public LocationAppService(BookingEngineDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, LocationValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
        }
        public async Task<LocationGetDto> GetByCountryCode(string countryCode)
        {
            var entity = await _serviceDbContext.Locations
                .FirstOrDefaultAsync(x => x.CountryCode == countryCode);

            return _mapper.Map<LocationGetDto>(entity);
        }

    }

}
