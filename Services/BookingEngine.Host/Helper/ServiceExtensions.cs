using AutoMapper;
using BookingEngine.Application.AirPortAppService;
using BookingEngine.Application.AirPortAppService.Dtos;
using BookingEngine.Application.AirPortAppService.Validations;
using BookingEngine.Application.AuditAppService;
using BookingEngine.Application.AuditAppService.Dtos;
using BookingEngine.Application.AuditAppService.Validations;
using BookingEngine.Application.Filters;
using BookingEngine.Application.OTAUserAppService;
using BookingEngine.Application.OTAUserAppService.Dtos;
using BookingEngine.Application.OTAUserAppService.Validations;
using BookingEngine.Application.OTAUserService;
using BookingEngine.Application.PassengerInfo;
using BookingEngine.Application.PassengerInfo.Dtos;
using BookingEngine.Application.PassengerInfo.Validations;
using BookingEngine.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Sieve.Services;

namespace BookingEngine.Host.Helper
{


    public static class ServiceExtensions
    {
        public static void AddCustomService(this IServiceCollection services)
        {
            services.AddTransient<IAirPortAppService, AirPortAppService>();
            services.AddTransient<AirPortValidator>();
            services.AddTransient<ISearchRequestAppService, SearchRequestAppService>();
            services.AddTransient<SearchRequestValidator>();
         
            services.AddTransient<IOTAUserAppService, OTAUserAppService>();
            services.AddTransient<OTAUserValidator>();

            services.AddTransient<IPassengerInfoAppService, PassengerInfoAppService>();
            services.AddTransient<PassengerInfoValidator>();


            services.AddScoped<IEncryptionAppService, EncryptionAppService>();
            

            services.AddScoped<ISieveProcessor, BookingEngineFilters>();
            services.AddSingleton<ISieveConfiguration, BookingEngineFiltersConfiguration>();



            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AirPortMapperProfile());
                mc.AddProfile(new SearchRequestMapperProfile());
                mc.AddProfile(new OTAUserMapperProfile());
                mc.AddProfile(new PassengerInfoMapperProfile());

            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            //services.AddScoped<ISieveProcessor, SieveProcessor>();

        }
    }







}
