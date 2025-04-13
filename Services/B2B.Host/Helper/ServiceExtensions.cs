using AutoMapper;
using B2B.Application.B2BAppService;
using B2B.Application.B2BAppService.Dto;
using B2B.Application.B2BAppService.Validations;
using Sieve.Services;

namespace B2B.Host.Helper
{
    public static class ServiceExtensions
    {
        public static void AddCustomService(this IServiceCollection services)
        {
            services.AddTransient<ITravelAgentOfficeAppService, TravelAgentOfficeAppService>();

            services.AddTransient<TravelAgentOfficeValidator>();

            services.AddScoped<ISieveProcessor, SieveProcessor>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new TravelAgentOfficeMapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
