using AutoMapper;
using BookingEngine.Application.AirPortAppService;
using BookingEngine.Application.AirPortAppService.Dtos;
using BookingEngine.Application.AirPortAppService.Validations;
using BookingEngine.Application.AuditAppService;
using BookingEngine.Application.AuditAppService.Dtos;
using BookingEngine.Application.AuditAppService.Validations;
using BookingEngine.Domain.Models;
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



            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AirPortMapperProfile());
                mc.AddProfile(new SearchRequestMapperProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddScoped<ISieveProcessor, SieveProcessor>();

        }
    }







}
