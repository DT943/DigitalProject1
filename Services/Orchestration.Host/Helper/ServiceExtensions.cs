using AutoMapper;
using CWCore.Application.LanguageAppService;
using CWCore.Application.LanguageAppService.Dtos;
using CWCore.Application.LanguageAppService.Validations;
using Sieve.Services;

namespace Orchestration.Host.Helper
{
    public static class ServiceExtensions
    {
        public static void AddCustomService(this IServiceCollection services)
        {


            services.AddTransient<ILanguageAppService, LanguageAppService>();
            services.AddTransient<LanguageValidator>();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new LanguageMapperProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<ISieveProcessor, SieveProcessor>();

        }
    }
}