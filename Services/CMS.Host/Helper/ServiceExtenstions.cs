using AutoMapper;
using CMS.Application.ComponentAppService;
using CMS.Application.ComponentAppService.Dto;
using CMS.Application.ComponentAppService.Validations;
using CMS.Application.PageAppService;
using CMS.Application.PageAppService.Dtos;
using CMS.Application.PageAppService.Validations;
using CMS.Application.SegmentAppService;
using CMS.Application.SegmentAppService.Dtos;
using CMS.Application.SegmentAppService.Validations;
using Sieve.Services;

namespace CMS.Host.Helper
{
    public static class ServiceExtenstions
    {
        public static void AddCustomService(this IServiceCollection services)
        {
            services.AddTransient<IPageAppService, PageAppService>();
            services.AddTransient<PageValidator>();

            services.AddTransient<ISegmentAppService, SegmentAppService>();
            services.AddTransient<SegmentValidator>();

            services.AddTransient<IComponentAppService, ComponentAppService>();
            services.AddTransient<ComponentValidator>();

            services.AddScoped<ISieveProcessor, SieveProcessor>();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new PageMapperProfile());
                mc.AddProfile(new SegmentMapperProfile());
                mc.AddProfile(new ComponentMapperProfile());


            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

        }
    }
}
