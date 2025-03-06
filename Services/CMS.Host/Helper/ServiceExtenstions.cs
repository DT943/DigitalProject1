using AutoMapper;
using CMS.Application.PageAppService;
using CMS.Application.PageAppService.Dtos;
using CMS.Application.PageAppService.Validations;
using Sieve.Services;

namespace CMS.Host.Helper
{
    public static class ServiceExtenstions
    {
        public static void AddCustomService(this IServiceCollection services)
        {
            services.AddTransient<IPageAppService, PageAppService>();
 
            services.AddTransient<PageValidator>();


            services.AddScoped<ISieveProcessor, SieveProcessor>();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new PageMapperProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

        }
    }
}
