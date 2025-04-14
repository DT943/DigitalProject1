using AutoMapper;
using B2B.Application.TravelAgentApplicationAppService;
using B2B.Application.TravelAgentApplicationAppService.Dto;
using B2B.Application.TravelAgentApplicationAppService.Validations;
using B2B.Application.TravelAgentOffice;
using B2B.Application.TravelAgentOffice.Dto;
using B2B.Application.TravelAgentOffice.Validations;
using Sieve.Services;

namespace B2B.Host.Helper
{
    public static class ServiceExtensions
    {
        public static void AddCustomService(this IServiceCollection services)
        {
            services.AddTransient<ITravelAgentOfficeAppService, TravelAgentOfficeAppService>();

            services.AddTransient<TravelAgentOfficeValidator>();

            services.AddTransient<ITravelAgentApplicationAppService, TravelAgentApplicationAppService>();

            services.AddTransient<TravelAgentApplicationValidator>();

            services.AddScoped<ISieveProcessor, SieveProcessor>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new TravelAgentOfficeMapperProfile());
                mc.AddProfile(new TravelAgentApplicationMapperProfile());

            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
